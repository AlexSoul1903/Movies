
using Movies.DAL.Entities;
using Movies.Service.Core;
using Movies.Service.Dtos;
using Movies.Service.Responses;

namespace Movies.Service.Contracts
{
  public interface IClientService:IBaseService
    {

        ClientSaveResponse SaveClient(ClientSaveDto clientSaveDto);
        ClientUpdateResponse UpdateClient(ClientUpdateDto clientUpdateDto);
        ServiceResult RemoveClient(ClientRemoveDto clientRemoveDto);
        ServiceResult GetClients();

    }
}
