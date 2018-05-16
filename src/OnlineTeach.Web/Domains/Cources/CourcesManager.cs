using OnlineTeach.Web.Data.Cource;
using OnlineTeach.Web.Domains.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Domains.Cources
{
    public class CourcesManager:AggrationRoot.AggrationRoot<long>
    {
        private IRepository<CourceItem, long> _courceManagerRepositoty;

        public CourcesManager(IRepository<CourceItem, long> repository)
        {
            _courceManagerRepositoty = repository;
        }

    }
}
