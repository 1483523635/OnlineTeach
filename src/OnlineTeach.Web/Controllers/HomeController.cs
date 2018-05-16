using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTeach.Web.Domains.Cources;
using OnlineTeach.Web.Models;
using OnlineTeach.Web.Models.CourceViewModels;

namespace OnlineTeach.Web.Controllers
{
    public class HomeController : Controller
    {
        private CourcesManager _courceManager;

        public HomeController(CourcesManager courceManager)
        {
            _courceManager = courceManager;
        }
        public IActionResult Index()
        {
            var list = _courceManager.GetAllCources();
            var model = Mapper.Map<List<CourceItemDisplayViewModel>>(list);
            return View(model);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
