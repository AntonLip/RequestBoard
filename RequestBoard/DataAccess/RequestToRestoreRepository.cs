using RequestBoard.Models.DbModels;
using RequestBoard.Models.Interfaces.IRepository;

namespace RequestBoard.DataAccess
{
    public class RequestToRestoreRepository : BaseRepository<RequestToRestore>, IRequestToRestoreRepository
    {
        public RequestToRestoreRepository(AppDbContext context)
            :base(context)
        {
            
        }
    }
}
