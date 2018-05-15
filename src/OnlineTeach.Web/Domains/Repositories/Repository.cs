using OnlineTeach.Web.Data;
using OnlineTeach.Web.Data.Adult;
using OnlineTeach.Web.Domains.AggrationRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Domains.Repositories
{
    public class Repository<TEntity, Tkey> : IRepository<TEntity, Tkey> where TEntity : AggrationRoot<Tkey>
    {
        private readonly AdultDbContext _context;

        public Repository(AdultDbContext adultDbContext)
        {
            _context = adultDbContext;
        }
        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Tkey key)
        {

            var entity = GetByKey(key);
            if (entity == null)
                throw new ArgumentException($"the entity not found , the Key is {key}");
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public TEntity GetByKey(Tkey key)
        {

            return _context.Set<TEntity>().FirstOrDefault(t => t.key.Equals(key));
        }

        public IEnumerable<TEntity> GetList()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Update(Tkey key, TEntity entity)
        {
            var entity_db = GetByKey(key);
            if (entity_db == null)
            {
                throw new ArgumentException($"the entity is not found ,key is {key}");
            }
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
    }
}
