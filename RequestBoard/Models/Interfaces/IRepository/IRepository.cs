using System.Linq.Expressions;

namespace RequestBoard.Models.Interfaces.IRepository
{
    public interface IRepository<TModel, TId>
            where TModel : IEntity<TId>
    {
        void AddEntity(TModel obj);
        IEnumerable<TModel> GetAllEntities();
        TModel GetEntityById(TId id);
        void UpdateEntity(TModel obj);
        TModel GetFirstEntity(Func<TModel, bool> predicate);
        List<TModel> GetWithInclude(params Expression<Func<TModel, object>>[] includeProperties);
        void RemoveEntity(TModel model);
        List<TModel> GetWithInclude(Func<TModel, bool> predicate,
            params Expression<Func<TModel, object>>[] includeProperties);

    }
}
