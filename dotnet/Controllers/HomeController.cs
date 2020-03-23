using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using dotnet.Models;
using System.Data.Entity;
using dotnet.Services;

namespace dotnet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AppDBContext db = new AppDBContext();

            var films = db.Films
                .Include(g => g.Genre);

            ViewBag.Films = films;

            return View();
        }
    }
}
