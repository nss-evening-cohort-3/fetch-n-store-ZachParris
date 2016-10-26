using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fetch_N_Store.Models
{
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }
        public string StatusCode { get; set; }
        public string URL { get; set; }
        public string ResponseTime { get; set; }
        public string Method { get; set; }
    }
}