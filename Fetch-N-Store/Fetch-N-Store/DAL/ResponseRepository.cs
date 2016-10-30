using Fetch_N_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fetch_N_Store.DAL
{
    public class ResponseRepository
    {
        public ResponseContext Context { get; set; }

        public ResponseRepository()
        {
            Context = new ResponseContext();
        }

        public ResponseRepository(ResponseContext _context)
        {
            Context = _context;
        }
        public List<Response> GetResponse()
        {
            return Context.Responses.ToList();
        }
        public void AddResponse(Response response)
        {
            Context.Responses.Add(response);
            Context.SaveChanges();
        }

        internal void DeleteResponse(int id)
        {
            Response response = Context.Responses.FirstOrDefault(r => r.ResponseId == id);
            Context.Responses.Remove(response);
            Context.SaveChanges();
        }
    }
}