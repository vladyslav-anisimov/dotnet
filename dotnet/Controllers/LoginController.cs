using System.Linq;
using System.Web.Mvc;
using dotnet.Models;
using dotnet.Services;

namespace dotnet.Controllers
{
    public class LoginController : Controller
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
        public ActionResult Login(LoginView model)
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                var loginedUser = (from user in db.Users
                                   where user.Email == model.Email.ToLower()
                                   select user).FirstOrDefault();
                
                if (loginedUser == null)
                {
                    ModelState.AddModelError("Email", "Email error.");
                }
                else if (Hash.HashPass(model.Password) == loginedUser.Password)
                {
                    Session["UserId"] = loginedUser.Id;
                    Session["UserTypeId"] = loginedUser.UserTypeId;

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Password", "Password error!");
            }

            return View("Index", model);
        }
    }
}
