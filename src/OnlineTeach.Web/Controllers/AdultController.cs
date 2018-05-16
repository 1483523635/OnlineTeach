using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTeach.Web.Data.Adult;
using OnlineTeach.Web.Domains.Cources;
using OnlineTeach.Web.Domains.Teachers;
using OnlineTeach.Web.Models.AdultViewModels;

namespace OnlineTeach.Web.Controllers
{
    [Authorize(Policy = "admin")]
    public class AdultController : Controller
    {
        private TeachersManager _teacherManager;
        private CourcesManager _courceManager;

        public AdultController(TeachersManager teacherManager, CourcesManager courceManager)
        {
            _teacherManager = teacherManager;
            _courceManager = courceManager;
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
        [HttpGet]
        public async Task<IActionResult> Pass(long id)
        {
            if (id <= 0)
                throw new ApplicationException("参数ID不正确！");
            await _teacherManager.Pass(id);
            StatusMessage = "已通过！";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Deny(long id)
        {
            if (id <= 0) throw new ApplicationException("参数ID不正确");
            _teacherManager.Deny(id);
            StatusMessage = "已拒绝！";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Cource()
        {
            var list = _courceManager.GetUnAdultCources();
            var model = AutoMapper.Mapper.Map<IEnumerable<CourceItemViewModel>>(list);
            ViewData["StatusMessage"] = StatusMessage;
            return View(model);
        }
        [HttpGet]
        public IActionResult CourcePass(long key)
        {
            if (key < 1)
                throw new ApplicationException("key 不能小于1");
            _courceManager.Pass(key);
            StatusMessage = "已通过审核！";
            return RedirectToAction(nameof(Cource));
        }

        [HttpGet]
        public IActionResult CourceDeny(long key)
        {
            if (key <= 0)
                throw new ApplicationException("key 不能小于1");
            _courceManager.Deny(key);
            StatusMessage = "已拒绝";
            return RedirectToAction(nameof(Cource));
        }
    }
}