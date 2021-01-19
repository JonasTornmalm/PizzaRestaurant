using PizzaRestaurant.Web.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.RESTClients
{
    public interface IInventoryServiceAPI
    {
        [Get("/inventory")]
        Task<HttpContent> GetInventory();

        [Patch("/inventory")]
        Task<HttpResponseMessage> MassDelivery();
        
        [Put("/inventory")]
        Task<HttpResponseMessage> EditInventory([Body(BodySerializationMethod.Serialized)] EditInventoryDTO editInventoryDTO);
    }
}
