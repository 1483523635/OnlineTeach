using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTeach.Web.Domains.Cources;
using OnlineTeach.Web.Models.CourceViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Controllers
{
    [Authorize(Roles = "teacher,admin")]
    public class CourceController : Controller
    {
        private CourcesManager _courceManager;

        public CourceController(CourcesManager courceManager)
        {
            _courceManager = courceManager;
        }

        [TempData]
        public string StatusMessage { get; set; }
        public IActionResult Index()
        {
            var list = _courceManager.GetAllCourcesByTeacherName(User.Identity.Name);
            var model = AutoMapper.Mapper.Map<IEnumerable<CourceItemCreateViewModel>>(list);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CourceItemCreateViewModel() { StateMessage = StatusMessage };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourceItemCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _courceManager.CreateCource(User.Identity.Name, model.Name,
                model.ImageUrl, model.StartTime, model.EndTime, model.Grade, model.Content, model.Price);
            StatusMessage = "创建成功！";
            return RedirectToAction(nameof(Create));
        }
    }
}
