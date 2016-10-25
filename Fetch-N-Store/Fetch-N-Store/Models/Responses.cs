using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fetch_N_Store.Models
{
    public class Responses
    {
        [Key]
        public int ResponseId { get; set; }
        public int StatusCode { get; set; }
        public string URL { get; set; }
        public string ResponseTime { get; set; }
        public string Method { get; set; }
    }
}