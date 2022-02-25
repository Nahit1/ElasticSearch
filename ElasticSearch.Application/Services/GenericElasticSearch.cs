using ElasticSearch.Application.Configurations;
using ElasticSearch.Application.Interfaces;
using ElasticSearch.Core.DTOs;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearch.Application.Services
{
    public class GenericElasticSearch<T> : IGenericElasticSearch<T> where T:class
    {
        ElasticClientProvider _provider;
        ElasticClient _client;

        public GenericElasticSearch(ElasticClientProvider provider)
        {
            _provider = provider;
            _client = _provider.ElasticClient;
        }
        public void CheckExistsAndInsertLog(T logMode, string indexName)
        {
            if (!_client.Indices.Exists(indexName).Exists)
            {
                var newIndexName = indexName + System.DateTime.Now.Ticks;

                var indexSettings = new IndexSettings();
                indexSettings.NumberOfReplicas = 1;
                indexSettings.NumberOfShards = 3;

                var response = _client.Indices.Create(newIndexName, index =>
                   index.Map<T>(m => m.AutoMap()
                          )
                  .InitializeUsing(new IndexState() { Settings = indexSettings })
                  .Aliases(a => a.Alias(indexName)));

            }
            //IndexResponse responseIndex = _client.Index<T>(logModel, idx => idx.Index(indexName));
            int a = 0;
        }

        public IReadOnlyCollection<LoginLogModel> SearchLoginLog(string userID, DateTime? BeginDate, DateTime? EndDate, string controller = "", string action = "", int? page = 0, int? rowCount = 10, string indexName = "login_log")
        {
            throw new NotImplementedException();
        }
    }
}
