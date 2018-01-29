using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityTest.Models;
using System.Web.Security;

namespace IdentityTest.Controllers
{
    public class LoginController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Login
        [Authorize(Roles ="Admin,Editor")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model, string returnUrl)
        {
            var data = db.Login.Where(x => x.usereName == model.usereName && x.Password == model.Password).FirstOrDefault();
            if (data != null)
            {
                FormsAuthentication.SetAuthCookie(Convert.ToString(data.ID),  false);                
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                 && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid user/pass");
                return View();
            }
            
        }
        [Authorize]
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}