using RequestBoard.Models.DbModels;

namespace RequestBoard.Models.Interfaces.IRepository
{
    public interface IRequestToRestoreRepository : IRepository<RequestToRestore, Guid>
    {
        List<RequestToRestore> FindRequestByPartOfName(string name);
    }
}
