using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineDoctorsAppointmentApp.Models;

namespace OnlineDoctorsAppointmentApp.Controllers
{
    public class LoginPanelController : Controller
    {
        AppDbContext db = new AppDbContext();

        //
        // GET: /LoginPanel/
        [AllowAnonymous]
        public ActionResult Index(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        //
        // POST: /LoginPanel/
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginInfo loginInfoInfo, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var authSystem = new AuthenticationSystem(HttpContext.GetOwinContext().Authentication);

                ///// STSTEM Admin Login /////
                if (loginInfoInfo.UserName == "sysadmin" && loginInfoInfo.Password == "sys123")
                {
                    bool isAdminRegistered = await authSystem.IsUserRegistered(loginInfoInfo.UserName, loginInfoInfo.Password);
                    if (isAdminRegistered)
                    {
                        await authSystem.SignInAsync(loginInfoInfo.UserName, loginInfoInfo.Password, false);
                    }
                    else
                    {
                        await authSystem.CreateAndSignInAsync(loginInfoInfo.UserName, loginInfoInfo.Password, false);
                    }

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ///// STSTEM Admin Login /////

                bool isValidUser =
                    db.Doctors.Count(d => d.UserName == loginInfoInfo.UserName && d.Password == loginInfoInfo.Password) > 0;
                if (isValidUser)
                {
                    await authSystem.SignInAsync(loginInfoInfo.UserName, loginInfoInfo.Password, loginInfoInfo.RememberMe);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
	}
}