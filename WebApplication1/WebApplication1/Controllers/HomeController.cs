using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult User()
        {
            UserModel userModel = new UserModel();
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                //Extract the forms authentication cookie
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                // If caching roles in userData field then extract
                String name = authTicket.Name;
                userModel.login = name;

            }
            return View(userModel);
        }

        [HttpPost]
        public ActionResult User(UserModel userModel)
        {
            if ((userModel.login.Equals("cat"))&& (userModel.password.Equals("dog"))){
              if (ModelState.IsValid)
              {
                   // FormsAuthentication.SetAuthCookie(userModel.login, false);
                  string userData = "data";

                  FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,                                     // ticket version
                    userModel.login,                              // authenticated username
                    DateTime.Now,                          // issueDate
                    DateTime.Now.AddMinutes(30),           // expiryDate
                    true,                          // true to persist across browser sessions
                    userData,                              // can be used to store additional user data
                    FormsAuthentication.FormsCookiePath);  // the path for the cookie

                  // Encrypt the ticket using the machine key
                  string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                  // Add the cookie to the request to save it
                  HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                  cookie.HttpOnly = true;
                  Response.Cookies.Add(cookie);

                }else
                {
                    userModel = new UserModel();  
                }
            }
            else
            {
                userModel = new UserModel();
            }

            return View(userModel);
        }
    }
}