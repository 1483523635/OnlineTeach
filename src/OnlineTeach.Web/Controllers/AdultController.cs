using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTeach.Web.Domains.Teachers;

namespace OnlineTeach.Web.Controllers
{
    [Authorize(Policy = "admin")]
    public class AdultController : Controller
    {
        private TeachersManager _teacherManager;

        public AdultController(TeachersManager teacherManager)
        {
            _teacherManager = teacherManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult Index()
        {
            var list = _teacherManager.GetAllApplys();

            return View();
        }

        //public IActionResult Pass(long Id)
        //{


        //}
        //public IActionResult Deny(long Id)
        //{

        //}
    }
}