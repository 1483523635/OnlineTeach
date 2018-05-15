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
            _teacherRepository.Add(new TeacherApply() { Name = name, RealName = realName, School = school, ApplyReason = applyReason });
        }
        public async Task AddToTeacherRoleAsync(ApplicationUser applicationUser)
        {
            var user = await _userManager.FindByNameAsync(applicationUser.UserName);
            if (user == null)
                throw new Exception("用户不存在！");
            if (!await _userManager.IsInRoleAsync(user, "teacher"))
                await _userManager.AddToRoleAsync(applicationUser, "teacher");
        }

    }
}
