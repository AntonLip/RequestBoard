using RequestBoard.Models.DbModels;
using RequestBoard.Models.Interfaces.IRepository;
using AutoMapper;
using RequestBoard.Models.DtoModels;

namespace RequestBoard.BusinessLayer
{
    public class BusinessLayerClass : IBusinessLayer
    {
        private readonly IRequestToRestoreRepository _requestToRestoreRepository;
        private readonly IRequestTypeRepository _requestTypeRepository;
        private readonly IMapper _mapper;
        public BusinessLayerClass(IRequestToRestoreRepository requestToRestoreRepository,  IRequestTypeRepository requestTypeRepository, IMapper mapper)
        {
            _requestToRestoreRepository = requestToRestoreRepository;
            _requestTypeRepository = requestTypeRepository;
            _mapper = mapper;
        }
        public RequestDto AddRequestToRestore(RequestToRestore model)
        {
            _requestToRestoreRepository.AddEntity(model);
            return _mapper.Map<RequestDto>(model);
        }

        public RequestType AddRequestType(RequestType model)
        {
            _requestTypeRepository.AddEntity(model);
            return model;
        }

        public List<RequestDto> GetAllRequestToRestore()
        {
             var dbmodels = _requestToRestoreRepository.GetAllEntities();
            return dbmodels is null ? throw new ArgumentException(nameof(dbmodels)) : _mapper.Map<List<RequestDto>>(dbmodels);
        }

        public List<RequestType> GetAllRequestType()
        {           
            return (List<RequestType>)_requestTypeRepository.GetAllEntities();
        }

        public RequestDto GetByIdRequestToRestore(Guid requestId)
        {
            var item = _requestToRestoreRepository.GetEntityById(requestId);
            return item is null ? throw new ArgumentException(nameof(item)) : _mapper.Map<RequestDto>(item);
        }

        public RequestType GetByIdRequestType(Guid requestTypeId)
        {
            return _requestTypeRepository.GetEntityById(requestTypeId);
        }

        public RequestDto RemoveRequestToRestore(Guid requestId)
        {
            var item = _requestToRestoreRepository.GetEntityById(requestId);
            _requestToRestoreRepository.RemoveEntity(item);
            return _mapper.Map<RequestDto>(item);
        }

        public RequestType RemoveRequestType(Guid requestTypeId)
        {
            var item = _requestTypeRepository.GetEntityById(requestTypeId);
            _requestTypeRepository.RemoveEntity(item);
            return item;
        }

        public RequestDto UpdateRequestToRestore(Guid requestId, RequestToRestore model)
        {
            _requestToRestoreRepository.UpdateEntity(model);
            var item = _requestToRestoreRepository.GetEntityById(requestId);
            return _mapper.Map<RequestDto>(item);
        }

        public RequestType UpdateRequestType(Guid requestTypeId, RequestType model)
        {
            _requestTypeRepository.UpdateEntity(model);
            return _requestTypeRepository.GetEntityById(requestTypeId);
        }
    }
}