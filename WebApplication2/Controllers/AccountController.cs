using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Web.Security;
using System.Net;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        private OfficeEntities db = new OfficeEntities();
        // GET: Account
      
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var context = new OfficeEntities())
            {
                bool isValid = context.User.Any(x => x.Email == model.Email && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "Users");
                }
                ModelState.AddModelError("", "Invalid Email and Password");
                return View();
            }
           
            
        }
       



        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User model)
        {

            using (var context = new OfficeEntities())
            {
                context.User.Add(model);
                context.SaveChanges();
            }
                return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}