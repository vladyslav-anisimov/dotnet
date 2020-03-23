using System.Web.Mvc;
using System.Linq;
using dotnet.Models;
using dotnet.Services;

namespace dotnet.Controllers
{
    public class RegisterController : Controller
    {
        AppDBContext db = new AppDBContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Register(RegisterView model)
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var emailExist = (from user in db.Users
                              where user.Email == model.Email.ToLower()
                              select user).FirstOrDefault();

            if (emailExist != null)
            {
                ModelState.AddModelError("Email", "Email address already exists.");
            }
            else if (ModelState.IsValid)
            {
                User user = new User {
                    Email = model.Email.ToLower(),
                    UserTypeId = UserType.USER,
                    Password = Hash.HashPass(model.Password)
                };

                db.Users.Add(user);
                db.SaveChanges();

                Session["UserId"] = user.Id;
                Session["UserTypeId"] = UserType.USER;

                return RedirectToAction("Index", "Home");
            }

            return View("Index", model);
        }
    }
}
