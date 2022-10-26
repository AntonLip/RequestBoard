using RequestBoard.Models.DbModels;
using RequestBoard.Models.Interfaces.IRepository;

namespace RequestBoard.DataAccess
{
    public class RequestTypeRepository : BaseRepository<RequestType>, IRequestTypeRepository
    {
        public RequestTypeRepository(AppDbContext context)
        : base(context)
        {

        }
    }
}