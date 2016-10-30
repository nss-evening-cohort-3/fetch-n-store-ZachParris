using Fetch_N_Store.DAL;
using Fetch_N_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fetch_N_Store.Controllers
{
    public class ResponseController : ApiController
    {
        ResponseRepository Repo = new ResponseRepository();
        // GET api/<controller>
        public IEnumerable<Response> Get()
        {
            List<Response> Responses = Repo.GetResponse();

            return Responses;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]dynamic data)
        {
            Response response = new Response() { StatusCode = data.status, Method = data.method, ResponseTime = data.time, URL = data.url };
            Repo.AddResponse(response);
                
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            ResponseRepository repo = new ResponseRepository();
            repo.DeleteResponse(id);
        }
    }
}