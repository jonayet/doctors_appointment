using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using OnlineDoctorsAppointmentApp.Models;

namespace OnlineDoctorsAppointmentApp.Controllers
{
    public class LoginPanelController : Controller
    {
        AppDbContext db = new AppDbContext();

        //
        // GET: /LoginPanel/
        public ActionResult Index(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        //
        // POST: /LoginPanel/
        [HttpPost]
        public async Task<ActionResult> Index(LoginInfo loginInfoInfo, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                bool isValidUser =
                    db.Doctors.Count(d => d.UserName == loginInfoInfo.UserName && d.Password == loginInfoInfo.Password) > 0;
                if (isValidUser)
                {
                    var aLoginViewModel = new LoginViewModel
                    {
                        UserName = loginInfoInfo.UserName,
                        Password = loginInfoInfo.Password,
                        RememberMe = loginInfoInfo.RememberMe
                    };

                    var ac = new AccountController();
                    await ac.Login(aLoginViewModel, ReturnUrl);
                }
            }
            return View();
        }


	}
}