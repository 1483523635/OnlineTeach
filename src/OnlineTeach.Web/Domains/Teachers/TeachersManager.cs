using Microsoft.AspNetCore.Identity;
using OnlineTeach.Web.Data.Adult;
using OnlineTeach.Web.Domains.Repositories;
using OnlineTeach.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Domains.Teachers
{
    public class TeachersManager : AggrationRoot.AggrationRoot<long>
    {
        private IRepository<TeacherApply, long> _teacherRepository;
        private UserManager<ApplicationUser> _userManager;

        public string Name { get; set; }
        public string RealName { get; set; }
        public string School { get; set; }
        public string ApplyReason { get; set; }
        public TeachersManager(IRepository<TeacherApply, long> repository, UserManager<ApplicationUser> useManager)
        {
            _teacherRepository = repository;
            _userManager = useManager;
        }
        public void ApplyToTeacherRole(string name, string realName, string school, string applyReason)
        {
            _teacherRepository.Add(new TeacherApply() { Name = name, RealName = realName, School = school, ApplyReason = applyReason, ApplyStatus = 1 });
        }
        public async Task AddToTeacherRoleAsync(string applicationUserName)
        {
            var user = await _userManager.FindByNameAsync(applicationUserName);
            if (user == null)
                throw new Exception("用户不存在！");
            if (!await _userManager.IsInRoleAsync(user, "teacher"))
                await _userManager.AddToRoleAsync(user, "teacher");

        }
        public IEnumerable<TeacherApply> GetAllApplys()
        {
            return _teacherRepository.GetList(t => t.ApplyStatus == 1);
        }
        public TeacherApply GetByKey(long key)
        {
            return _teacherRepository.GetByKey(key);
        }
        public async Task Pass(long id)
        {
            var user = GetByKey(id);
            await AddToTeacherRoleAsync(user.Name);
            UpdateApplyStatus(id, 3);
        }
        public void Deny(long id)
        {
            var user = GetByKey(id);
            UpdateApplyStatus(id, 2);
            UpdateApplyConut(id);
        }
        private void UpdateApplyStatus(long key, int status)
        {
            var apply = GetByKey(key);
            apply.ApplyStatus = status;
            _teacherRepository.Update(key, apply);
        }
        private void UpdateApplyConut(long key)
        {
            var apply = GetByKey(key);
            apply.ApplyCount += 1;
            _teacherRepository.Update(key, apply);
        }
    }
}
