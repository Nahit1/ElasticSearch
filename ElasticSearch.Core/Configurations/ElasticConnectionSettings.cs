using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearch.Core.Configurations
{
    public class ElasticConnectionSettings
    {
        public string ElasticSearchHost { get; set; }
        public string ElasticLoginIndex { get; set; }
        public string ElasticErrorIndex { get; set; }
        public string ElasticAuditIndex { get; set; }
    }
}
