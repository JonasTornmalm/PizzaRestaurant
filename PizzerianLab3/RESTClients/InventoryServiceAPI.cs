using Microsoft.Extensions.Configuration;
using PizzerianLab3.Data.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzerianLab3.RESTClients
{
    public class InventoryServiceAPI : IInventoryServiceAPI
    {
        private IInventoryServiceAPI _restClient;
        public InventoryServiceAPI(IConfiguration config, HttpClient httpClient)
        {
            string apiHostAndPort = config.GetSection("APIServiceLocations").GetValue<string>("InventoryServiceAPI");
            httpClient.BaseAddress = new Uri($"http://{apiHostAndPort}/api");
            _restClient = RestService.For<IInventoryServiceAPI>(httpClient);
        }
        public async Task<HttpResponseMessage> ProcessOrder(Order cart)
        {
            return await _restClient.ProcessOrder(cart);
        }
    }
}
