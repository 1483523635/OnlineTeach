using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTeach.Web.Domains.Cources;
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
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
