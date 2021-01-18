using PizzaRestaurant.Web.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.RESTClients.Interfaces
{
    public interface IPizzaServiceAPI
    {
        // Menu
        [Get("/pizzeria")]
        Task<HttpContent> GetMenu();

        // Cart
        [Get("/cart")]
        Task<HttpContent> GetCartContent();

        [Post("/cart")]
        Task<HttpResponseMessage> AddToCart([Body(BodySerializationMethod.Serialized)] AddToCartDTO addToCartDTO);

        // Order
    }
}
