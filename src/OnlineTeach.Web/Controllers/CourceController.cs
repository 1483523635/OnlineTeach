using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Controllers
{
    [Authorize(Roles ="teacher,admin")]
    public class CourceController : ControllerBase
    {
        public IActionResult Index()
        {
            return Content("SUCCESS");
        }
    }
}
