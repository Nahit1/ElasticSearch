using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearch.Core.DTOs
{
    public class LoginLogModel
    {
        public string UserID { get; set; }
        public DateTime Date { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
