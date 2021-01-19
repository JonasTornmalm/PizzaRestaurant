using PizzerianLab3.Data.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzerianLab3.RESTClients
{
    public interface IInventoryServiceAPI
    {
        [Post("/inventory")]
        Task<HttpResponseMessage> ProcessOrder([Body(BodySerializationMethod.Serialized)] Order cart);
    }
}
