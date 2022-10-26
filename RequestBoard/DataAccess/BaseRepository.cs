using System.Linq.Expressions;
using RequestBoard.Models.Interfaces;
using RequestBoard.Models.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace RequestBoard.DataAccess
{
    public class BaseRepository<TModel> : IRepository<TModel, Guid>
        where TModel : class, IEntity<Guid>
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TModel> _dbSet;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TModel>();
        }
        public void AddEntity(TModel obj)
        {
            _dbSet.Add(obj);
            _context.SaveChanges();
        }
        public IEnumerable<TModel> GetAllEntities()
        {
            return _dbSet.ToList();
        }
        public TModel GetEntityById(Guid id)
        {
            return _dbSet.First(l => l.Id == id);
        }
        public TModel GetFirstEntity(Func<TModel, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).FirstOrDefault();
        }
        public List<TModel> GetWithInclude(params Expression<Func<TModel, object>>[] includeProperties)
        {
             return Include(includeProperties).ToList();
        }
        public List<TModel> GetWithInclude(Func<TModel, bool> predicate, params Expression<Func<TModel, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }
        public void RemoveEntity(TModel model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            _context.SaveChanges();
        }
        public void UpdateEntity(TModel obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        private IQueryable<TModel> Include(params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
