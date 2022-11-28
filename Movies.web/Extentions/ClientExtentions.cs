using Movies.Service.Models;
using Movies.web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Movies.web.Extentions

{
    public  static class ClientExtentions
    {

        public static List<Client> ConvertClientModelToModel(this List<Service.Models.ClientModel> clientModels)
        {
            var myClients = clientModels.Select(client => new Client()
            {
                LastName = client.LastName,
                Age = client.Age,
                Email = client.Email,
                Name = client.Name,
                Id = client.Id,
                Password = client.Password,
                PaymentMethodId = client.PaymentMethodId
            }).ToList();

            return myClients;

        }

        public static List<Client> GetClient(List<Service.Models.ClientModel> clientModels)
        {
            var myClients = clientModels.Select(client => new Client()
            {
                Age=client.Age,
                Email=client.Email,
                Id=client.Id,
                LastName=client.LastName,
                Name=client.Name,
                Password=client.Password,
                PaymentMethodId=client.PaymentMethodId
            }).ToList();

            return myClients;
        }


        public static Models.Client ConvertFromClientModelToClient(this ClientModel clientModel)
        {
            return new Models.Client()
            {
                Age= clientModel.Age,
                Email=clientModel.Email,
                Id=clientModel.Id,
                LastName=clientModel.LastName,
                Name=clientModel.Name,
                Password=clientModel.Password,
                PaymentMethodId=clientModel.PaymentMethodId
            };
        }



    }
}
