using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using TwentyOneDayApp.Models;

namespace TwentyOneDayApp.Controllers
{
    public class BaseController : Controller
    {
        public ModelContext Context { get; set; }

        public BaseController()
        {
            Context = new ModelContext();
        }

        public User CurrentUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    var name = User.Identity.Name;
                    return Context.Users.FirstOrDefault(f => f.Username == name);
                }
                return null;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.user = CurrentUser;
        }
    }
}