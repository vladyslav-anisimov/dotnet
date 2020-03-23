﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using System;
using dotnet.Models;

namespace dotnet.Controllers
{
    public class GenreController : Controller
    {
        AppDBContext db = new AppDBContext();

        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["UserTypeId"]) != UserType.ADMIN)
            {
                return RedirectToAction("Index", "Home");
            }

            IEnumerable<Genre> genres = db.Genres;

            return View(genres);
        }

        public ActionResult Create()
        {
            if (Convert.ToInt32(Session["UserTypeId"]) != UserType.ADMIN)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (Convert.ToInt32(Session["UserTypeId"]) != UserType.ADMIN)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                db.Genres.Add(genre);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return HttpNotFound();
            }
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

            var genre = db.Genres.Find(id);

            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);
        }

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (Convert.ToInt32(Session["UserTypeId"]) != UserType.ADMIN)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                db.Entry(genre).State = EntityState.Modified;
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
                var genre = db.Genres.Find(id);
                db.Genres.Remove(genre);
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
