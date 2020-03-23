using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using dotnet.Models;
using System.Linq;
using System;

namespace dotnet.Controllers
{
    public class FilmController : Controller
    {
        AppDBContext db = new AppDBContext();

        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["UserTypeId"]) != UserType.ADMIN)
            {
                return RedirectToAction("Index", "Home");
            }

            IEnumerable<Film> Films = db.Films.Include(g => g.Genre);

            return View(Films);
        }

        public ActionResult Create()
        {
            if (Convert.ToInt32(Session["UserTypeId"]) != UserType.ADMIN)
            {
                return RedirectToAction("Index", "Home");
            }

            SelectList genres = new SelectList(db.Genres, "Id", "Name");
            ViewBag.Genres = genres;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Film film)
        {
            if (Convert.ToInt32(Session["UserTypeId"]) != UserType.ADMIN)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Details(int? id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return HttpNotFound();
            }

            var film = db.Films
                .Include(f => f.Genre)
                .FirstOrDefault(f => f.Id == id);

            if (film == null)
            {
                return HttpNotFound();
            }

            return View(film);
        }

        public ActionResult Edit(int? id)
        {
            if (Convert.ToInt32(Session["UserTypeId"]) != UserType.ADMIN)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return HttpNotFound();
            }

            var Film = db.Films.Find(id);

            if (Film != null)
            {
                var genres = new SelectList(db.Genres, "Id", "Name", Film.GenreId);
                ViewBag.Genres = genres;
                return View(Film);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Film Film)
        {
            if (Convert.ToInt32(Session["UserTypeId"]) != UserType.ADMIN)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                db.Entry(Film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return HttpNotFound();
            }
        }

        public ActionResult Delete(int id)
        {
            if (Convert.ToInt32(Session["UserTypeId"]) != UserType.ADMIN)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                var geme = db.Films.Find(id);
                db.Films.Remove(geme);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return HttpNotFound();
            }
        }
    }
}
