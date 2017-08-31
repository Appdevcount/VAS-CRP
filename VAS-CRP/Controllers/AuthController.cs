using Auth.Model;
using Auth.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VAS_CRP.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult RequestLogin()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(CustomAccountViewModel cred)
        {
            CustomAccountModel cam = new CustomAccountModel();

            if (cam.login(cred.acct.Username, cred.acct.password) != null)
            {
                Session["Username"] = cred.acct.Username;
                SessionPersister.username = cred.acct.Username;
                //return RedirectToAction("../OnSDPSvcRpt/KuwaitZainOnSDPReport");
                return RedirectToAction("Welcome","Home");
            }
            ViewBag.InvalidCredential = "Invalid Username or Password ";
            return View("Login");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            SessionPersister.username = string.Empty;
            return RedirectToAction("Login","Auth");
        }
        public ActionResult NotAuthorized()
        {
            return View();
        }

    }
}