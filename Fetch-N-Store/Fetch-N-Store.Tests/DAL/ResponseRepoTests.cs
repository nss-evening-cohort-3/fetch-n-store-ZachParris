using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fetch_N_Store.DAL;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Fetch_N_Store.Models;
using System.Data.Entity;

namespace Fetch_N_Store.Tests.DAL
{
    [TestClass]
    public class ResponseRepositoryTests
    {
        Mock<ResponseContext> mock_context { get; set; }
        Mock<DbSet<Response>> mock_response_table { get; set; }
        List<Response> response_list { get; set; }
        ResponseRepository repo { get; set; }

        public void ConnectMocksToDatastore()
        {
            var queryable_list = response_list.AsQueryable();

            // Lie to LINQ make it think that our new Queryable List is a Database table.
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            // Have our Author property return our Queryable List AKA Fake database table.
            mock_context.Setup(c => c.Responses).Returns(mock_response_table.Object);

            mock_response_table.Setup(t => t.Add(It.IsAny<Response>())).Callback((Response v) => response_list.Add(v));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<ResponseContext>();
            mock_response_table = new Mock<DbSet<Response>>();
            response_list = new List<Response>();
            repo = new ResponseRepository(mock_context.Object);

            ConnectMocksToDatastore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void RepoEnsureCanCreateInstance()
        {
            ResponseRepository repo = new ResponseRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureRepoHasContext()
        {
            ResponseRepository repo = new ResponseRepository();

            ResponseContext actual_context = repo.Context;

            Assert.IsInstanceOfType(actual_context, typeof(ResponseContext));
        }

        [TestMethod]
        public void RepoEnsureWeHaveNoStudents()
        {
            List<Response> actual_response = repo.GetResponse();
            int expected_response_count = 0;
            int actual_response_count = actual_response.Count;

            Assert.AreEqual(expected_response_count, actual_response_count);
        }

    }
}
