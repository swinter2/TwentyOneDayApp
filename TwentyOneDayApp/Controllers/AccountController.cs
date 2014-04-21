using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TwentyOneDayApp.Models;
using TwentyOneDayApp.ViewModels;

namespace TwentyOneDayApp.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = Context.Users.FirstOrDefault(f => f.Username == model.Username && f.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Incorrect username or password.");
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(user.Username, true);
            return Redirect(FormsAuthentication.DefaultUrl);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return Redirect(FormsAuthentication.DefaultUrl);
        }

        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!model.Password.Equals(model.ConfirmPassword))
                ModelState.AddModelError(string.Empty, "Passwords must match.");

            if (!ModelState.IsValid)
                return View(model);

            var user = Context.Users.FirstOrDefault(f=> f.Username == model.Username);
            if (user != null)
            {
                ModelState.AddModelError(string.Empty, "Username is already taken.  Please choose another.");
                return View(model);
            }

            // Otherwise, create this new user and sign them in.
            user = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    ContainerCollections = new List<ContainerCollection>
                        {
                            ContainerCollection.CreateDefault()
                        }
                };
            Context.Users.Add(user);

            FormsAuthentication.SetAuthCookie(user.Username, true);
            return Redirect(FormsAuthentication.DefaultUrl);
        }
    }
}