﻿using Microsoft.Extensions.Configuration;
using PizzaRestaurant.Web.DTOs;
using PizzaRestaurant.Web.RESTClients.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.RESTClients
{
    public class PizzaServiceAPI : IPizzaServiceAPI
    {
        private IPizzaServiceAPI _restClient;
        public PizzaServiceAPI(IConfiguration config, HttpClient httpClient)
        {
            string apiHostAndPort = config.GetSection("APIServiceLocations").GetValue<string>("PizzaServiceAPI");
            httpClient.BaseAddress = new Uri($"http://{apiHostAndPort}/api");
            _restClient = RestService.For<IPizzaServiceAPI>(httpClient);
        }
        public async Task<HttpContent> GetMenu()
        {
            return await _restClient.GetMenu();
        }
        public async Task<HttpContent> GetCartContent()
        {
            return await _restClient.GetCartContent();
        }
        public async Task<HttpResponseMessage> AddToCart(AddToCartDTO addToCartDTO)
        {
            return await _restClient.AddToCart(addToCartDTO);
        }
        public async Task<HttpResponseMessage> ClearCart()
        {
            return await _restClient.ClearCart();
        }
        public async Task<HttpResponseMessage> AddExtraIngredients(UpdateCartDTO updateCartDTO)
        {
            return await _restClient.AddExtraIngredients(updateCartDTO);
        }
        public async Task<HttpContent> GetPendingOrders()
        {
            return await _restClient.GetPendingOrders();
        }

        public async Task<HttpResponseMessage> PlaceOrder()
        {
            return await _restClient.PlaceOrder();
        }
    }
}
