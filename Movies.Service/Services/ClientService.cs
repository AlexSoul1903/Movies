using Movies.Service.Contracts;
using Movies.Service.Core;
using Movies.Service.Dtos;
using Movies.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Movies.Service.Exceptions;
using Movies.Service.Models;
using Movies.Service.Validations;

namespace Movies.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientsRepository clientsRepository;
        private readonly ILoggerService<ClientService> logger;

        public ClientService(IClientsRepository clientsRepository, ILoggerService<ClientService> logger)
        {

            this.clientsRepository = clientsRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {

            ServiceResult result = new ServiceResult();

            try
            {
                var clients = clientsRepository.GetEntities();

                result.Data = clients.Select(st => new Models.ClientModel()
                {
                    Age=st.Age,
                    Id=st.Id,
                    Email=st.Email,
                    LastName=st.LastName,
                    Name=st.Name,
                    Password=st.Password,
                    PaymentMethodId=st.PaymentMethodId
 
                }).ToList();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the clients";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;

        }

        public ServiceResult GetById(int Id)
        {


            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Clients client = clientsRepository.GetEntity(Id);

                ClientModel model = new ClientModel()
                {
                    Id=client.Id,
                    Age=client.Age,
                    Email=client.Email,
                    LastName=client.LastName,
                    Name=client.Name,
                    Password=client.Password,
                    PaymentMethodId=client.PaymentMethodId
                };

                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the client Id.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;


        }

        public ServiceResult GetClients()
        {
            ServiceResult result = new ServiceResult();


            try
            {

                var clients = clientsRepository.GetEntities();

                result.Data = clients.Select(st => new Models.ClientModel()
                {
                    Id= st.Id,
                    Age=st.Age,
                    Email=st.Email,
                    LastName=st.LastName,
                    Name=st.Name,
                    PaymentMethodId=st.PaymentMethodId,
                    Password=st.Password


                });

            } 
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the clients";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult RemoveClient(ClientRemoveDto clientRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {


                ClientSaveResponse client = new ClientSaveResponse();

                DAL.Entities.Clients clientToRemove = clientsRepository.GetEntity(clientRemoveDto.Id);

                clientToRemove.Id = clientRemoveDto.Id;
                clientToRemove.DeletedDate = DateTime.Now;

                clientsRepository.Remove(clientToRemove);

                result.Message = "The client was deleted";


            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error delenting the client";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());


            }

            return result;

        }

        public ClientSaveResponse SaveClient(ClientSaveDto clientSaveDto)
        {
            ClientSaveResponse result = new ClientSaveResponse();

            try
            {
               
                var resutlIsValid = ValidationsClient.IsValidClient(clientSaveDto);

                if (resutlIsValid.Success)
                {

                    // Verificar si el estudiante esta registrado //
                    if (clientsRepository.Exists(st => st.Name == clientSaveDto.Name && st.LastName == clientSaveDto.LastName))
                        {

                            result.Success = false;
                            result.Message = "This client is alredy registered.";
                            return result;
                        }

                        DAL.Entities.Clients ClientToAdd = new DAL.Entities.Clients()
                        {
                            LastName = clientSaveDto.LastName,
                            Name = clientSaveDto.Name,
                            CreationDate = DateTime.Now,
                            Age=clientSaveDto.Age,
                            Email=clientSaveDto.Email,
                            Password=clientSaveDto.Password,
                            PaymentMethodId=clientSaveDto.PaymentMethodId
                        };

                    clientsRepository.Save(ClientToAdd);

                    result.Id = ClientToAdd.Id;

                        result.Message = "The client was added successfully";

                    }
                
                else
                {
                    result.Success = resutlIsValid.Success;
                    result.Message = resutlIsValid.Message;
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error adding the client";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }
            return result;
        }

      
      

        ClientUpdateResponse IClientService.UpdateClient(ClientUpdateDto clientUpdateDto)
        {

           ClientUpdateResponse result = new ClientUpdateResponse();

            try
            {
           

                var resultIsValid = ValidationsClient.IsValidClient(clientUpdateDto);

                if (resultIsValid.Success)
                {

                   if (clientUpdateDto.Id == null)
                    {
                        result.Success = false;
                        result.Message = "An Id must be provided in order to update a client";
                        return result;
                    }

                        DAL.Entities.Clients clientToUpdate = clientsRepository.GetEntity((int)clientUpdateDto.Id); // Se busca el estudiante a actualizar //

                    clientToUpdate.Name = clientUpdateDto.Name;
                       clientToUpdate.LastName = clientUpdateDto.LastName;
                    clientToUpdate.Password = clientUpdateDto.Password;
                    clientToUpdate.PaymentMethodId = clientUpdateDto.PaymentMethodId;
                    clientToUpdate.UpdatedDate = DateTime.Now;
                    clientsRepository.Update(clientToUpdate);

                        result.Message = "Client updated successfully";
                    }
                   

    
                else
                {
                    result.Success = false;
                    result.Message = resultIsValid.Message;
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error updating the client";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;




        }
    }
}
