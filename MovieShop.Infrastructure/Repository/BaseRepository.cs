using Microsoft.EntityFrameworkCore;
using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repository
{
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
        protected readonly MovieShopDbContext _context;

        public BaseRepository(MovieShopDbContext context)
        {
            _context = context;
        }

        public T Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T DeleteById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
                return null;
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
