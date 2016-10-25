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
        public List<Responses> GetResponse()
        {
            return Context.Responses.ToList();
        }
    }
}