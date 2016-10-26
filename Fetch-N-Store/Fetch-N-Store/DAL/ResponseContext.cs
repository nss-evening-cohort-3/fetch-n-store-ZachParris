using Fetch_N_Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fetch_N_Store.DAL
{
    public class ResponseContext
    {
        public virtual DbSet<Response> Responses { get; set; }
    }
}