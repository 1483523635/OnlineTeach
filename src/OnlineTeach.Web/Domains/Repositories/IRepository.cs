using OnlineTeach.Web.Data.Adult;
using OnlineTeach.Web.Domains.AggrationRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Domains.Repositories
{
    public interface IRepository<TModel, TKey> where TModel : AggrationRoot<TKey>
    {
        void Add(TModel teacher);
        void Update(TKey key, TModel teacher);
        TModel GetByKey(TKey key);
        IEnumerable<TModel> GetList();
        IEnumerable<TModel> GetList(Expression<Func<TModel, bool>> expression);
        void Delete(TKey key);
    }
}
