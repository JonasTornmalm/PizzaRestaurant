using Microsoft.Extensions.Configuration;
using PizzaRestaurant.Web.DTOs;
using PizzaRestaurant.Web.RESTClients;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.RESTClients
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
        public async Task<HttpContent> GetInventory()
        {
            return await _restClient.GetInventory();
        }
        public async Task<HttpResponseMessage> MassDelivery()
        {
            return await _restClient.MassDelivery();
        }
        public async Task<HttpResponseMessage> EditInventory(EditInventoryDTO editInventoryDTO)
        {
            return await _restClient.EditInventory(editInventoryDTO);
        }
    }
}
