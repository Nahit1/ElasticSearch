using ElasticSearch.Core.Configurations;
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearch.Application.Configurations
{
    public class ElasticClientProvider
    {
        public ElasticClient ElasticClient { get; }

        public string ElasticSearchHost { get; set; }
        public ElasticClientProvider(IOptions<ElasticConnectionSettings> elasticConfig)
        {
            ElasticSearchHost = elasticConfig.Value.ElasticSearchHost;
            ElasticClient = CreateClient();
        }

        private ElasticClient CreateClient()
        {
            var connectionSettings = new ConnectionSettings(new Uri(ElasticSearchHost))
                .DisablePing()
                .DisableDirectStreaming(true)
                .SniffOnStartup(false)
                .SniffOnConnectionFault(false);

            return new ElasticClient(connectionSettings);
        }

        public ElasticClient CreateClientWithIndex(string defaultIndex)
        {
            var connectionSettings = new ConnectionSettings(new Uri(ElasticSearchHost))
                .DisablePing()
                .SniffOnStartup(false)
                .SniffOnConnectionFault(false)
                .DefaultIndex(defaultIndex);

            return new ElasticClient(connectionSettings);
        }

        
    }
}
