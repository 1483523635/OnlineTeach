using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTeach.Web.Data.Adult;
using OnlineTeach.Web.Domains.Teachers;
using OnlineTeach.Web.Models.AdultViewModels;

namespace OnlineTeach.Web.Controllers
{
    [Authorize(Policy = "admin")]
    public class AdultController : Controller
    {
        private TeachersManager _teacherManager;
        private static bool IsInited = false;
        private static readonly object _lock = new object();
        public AdultController(TeachersManager teacherManager)
        {
            _teacherManager = teacherManager;
            if (!IsInited)
            {
                lock (_lock)
                {
                    if (!IsInited)
                    {
                        AutoMapper.Mapper.Initialize(config => config.CreateMap<TeacherApply, TeacherApplyViewModel>().ConstructUsing(c => new TeacherApplyViewModel() { Id = c.key }));
                        IsInited = true;
                    }
                }
            }
        }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult Index()
        {
            var list = _teacherManager.GetAllApplys();
            var model = AutoMapper.Mapper.Map<List<TeacherApplyViewModel>>(list);
            ViewBag.StatusMessage = StatusMessage;
            return View(model);
        }

        public async Task<IActionResult> Pass(long id)
        {
            if (id <= 0)
                throw new ApplicationException("参数ID不正确！");
            await _teacherManager.Pass(id);
            StatusMessage = "已通过！";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Deny(long id)
        {
            if (id <= 0) throw new ApplicationException("参数ID不正确");
            _teacherManager.Deny(id);
            StatusMessage = "已拒绝！";
            return RedirectToAction(nameof(Index));
        }
    }
}