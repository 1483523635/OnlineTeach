using OnlineTeach.Web.Data.Cource;
using OnlineTeach.Web.Domains.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Domains.Cources
{
    public class CourcesManager : AggrationRoot.AggrationRoot<long>
    {
        private IRepository<CourceItem, long> _courceManagerRepositoty;

        public CourcesManager(IRepository<CourceItem, long> repository)
        {
            _courceManagerRepositoty = repository;
        }
        public void CreateCource(string userName, string name, string imageUrl, DateTime startTime, DateTime endTime, GradeType gradeType, string content, double price)
        {
            _courceManagerRepositoty.Add(new CourceItem() { Name = name, ImageUrl = imageUrl, StartTime = startTime, EndTime = endTime, Grade = gradeType, Content = content, Price = price, BookCount = 0, State = CourceState.UnAdult, TeacherName = userName });
        }
        public IEnumerable<CourceItem> GetUnAdultCources()
        {
            return _courceManagerRepositoty.GetList(c => c.State == CourceState.UnAdult);
        }
        public IEnumerable<CourceItem> GetAllCources()
        {
            return _courceManagerRepositoty.GetList(c => c.State == CourceState.Pass);
        }
        public IEnumerable<CourceItem> GetAllCourcesByTeacherName(string teacherName)
        {
            return _courceManagerRepositoty.GetList(c => c.TeacherName == teacherName);
        }
        public void Pass(long Key)
        {
            var cource = GetByKey(key);
            cource.State = CourceState.Pass;
            _courceManagerRepositoty.SaveChanges();
        }
        public void Deny(long key)
        {
            var cource = GetByKey(key);
            cource.State = CourceState.Deny;
            _courceManagerRepositoty.SaveChanges();
        }
        public void Delete(long key)
        {
           // var cource = GetByKey(key);
            _courceManagerRepositoty.Delete(key);
        }
        public CourceItem GetByKey(long key)
        {
            return _courceManagerRepositoty.GetByKey(key);
        }
    }
}
