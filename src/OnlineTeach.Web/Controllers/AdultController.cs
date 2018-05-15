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
                        AutoMapper.Mapper.Initialize(config => config.CreateMap<TeacherApply, TeacherApplyViewModel>().ConstructUsing(c=>new TeacherApplyViewModel() { Id=c.key}));
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
            return View(model);
        }

        //public IActionResult Pass(long Id)
        //{


        //}
        //public IActionResult Deny(long Id)
        //{

        //}
    }
}