using Microsoft.EntityFrameworkCore;
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

        public List<RequestToRestore> FindRequestByPartOfName(string name)
        {
            
            var ret =  _dbSet.AsNoTracking().Where(p => EF.Functions.Like(p.Name, $"%{name}%")).ToList();
            return ret;
        }
    }
}
