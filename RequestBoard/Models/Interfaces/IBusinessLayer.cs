using RequestBoard.Models.DbModels;
using RequestBoard.Models.DtoModels;

namespace RequestBoard.Models.Interfaces.IRepository
{
    public interface IBusinessLayer
    {
        RequestDto AddRequestToRestore(RequestToRestore model);
        RequestDto RemoveRequestToRestore(Guid requestId);
        RequestDto UpdateRequestToRestore(Guid requestId, RequestToRestore model);
        List<RequestDto> GetAllRequestToRestore();
        RequestDto GetByIdRequestToRestore(Guid requestId);
        RequestType AddRequestType(RequestType model);
        RequestType RemoveRequestType(Guid requestTypeId);
        RequestType UpdateRequestType(Guid requestTypeId, RequestType model);
        List<RequestType> GetAllRequestType();
        RequestType GetByIdRequestType(Guid requestTypeId);
    }
}