using AutoMapper;
using RequestBoard.Models.DbModels;
using RequestBoard.Models.DtoModels;
using RequestBoard.Models.Interfaces.IRepository;

namespace RequestBoard.Models
{
    internal class RequestTypeResolver : IValueResolver<RequestToRestore, RequestDto, string>
    {
        private readonly IRequestTypeRepository _requestTypeRepository;
        public RequestTypeResolver(IRequestTypeRepository requestTypeRepository)
        {
            _requestTypeRepository = requestTypeRepository;
        }
        public string Resolve(RequestToRestore source, RequestDto destination, string destMember, ResolutionContext context)
        {
            var item = _requestTypeRepository.GetEntityById(source.RequestTypeId);
            return item is null ? throw new ArgumentNullException(nameof(item)) : item.Name;
        }
    }
}