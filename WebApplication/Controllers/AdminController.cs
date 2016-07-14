using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (ValidateUser(model.UserName, model.Password))
                {
                        return SetAuthCookie(model.UserName, model.RememberMe, returnUrl);
                }
                else
                {
                   ModelState.AddModelError("", "Неправильный пароль или логин");
                }
            }
            return View(model);
        }

        private ActionResult SetAuthCookie(string userName, bool rememberMe, string returnUrl)
        {
            FormsAuthentication.SetAuthCookie(userName, rememberMe);
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Game");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Game");
        }

        private bool ValidateUser(string login, string password)
        {
            bool isValid = false;

            using (HelpDeskContext db = new HelpDeskContext())
            {
                try
                {
                    User user = (from u in db.Users
                                 where u.Login == login && u.Password == password
                                 select u).FirstOrDefault();

                    if (user != null)
                    {
                        isValid = true;
                    }
                }
                catch
                {
                    isValid = false;
                }
            }
            return isValid;
        }
    }
}