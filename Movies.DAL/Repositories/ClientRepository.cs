using Microsoft.Extensions.Logging;
using Movies.DAL.Context;
using Movies.DAL.Entities;
using Movies.DAL.Interfaces;
using Movies.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Repositories
{
    public class ClientRepository : IClientsRepository
    {

        private readonly MoviesContext context;
        private readonly ILogger<ClientRepository> logger;

        public ClientRepository(MoviesContext context, ILogger<ClientRepository> logger)
        {

            this.context = context;
            this.logger = logger;

        }

        public bool Exists(Expression<Func<Clients, bool>> filter)
        {
            return context.Clients.Any(filter);
        }

        public IEnumerable<Clients> GetEntities()
        {
            return context.Clients;
        }

        public Clients GetEntity(int clientId)
        {
            return context.Clients.Find(clientId);
        }


        public void Remove(Clients client)
        {
            client.DeletedDate = DateTime.Now;
            context.Clients.Remove(client);
        
        }

      

        public void Save(Clients client)
        {
          
            context.Clients.Add(client);
            context.SaveChanges();
        }

     
            public void Update(Clients clients)
            {
                try
                {
                    Clients clientToModify = GetEntity(clients.Id);

                    clientToModify.Name = clients.Name;
                    clientToModify.LastName = clients.LastName;
                    clientToModify.Age = clients.Age;
                    clientToModify.Email = clients.Email;
                clientToModify.UpdatedDate = DateTime.Now;

                    context.Clients.Update(clientToModify);
                }
                catch (Exception ex)
                {
                    this.logger.LogError($"Error: {ex.Message}", ex.ToString());
                }



            }
        }
    }




