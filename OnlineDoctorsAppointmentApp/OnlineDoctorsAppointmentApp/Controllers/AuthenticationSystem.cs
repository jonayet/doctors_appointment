using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using OnlineDoctorsAppointmentApp.Models;

namespace OnlineDoctorsAppointmentApp.Controllers
{
    public class AuthenticationSystem
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public IAuthenticationManager AuthenticationManager { get; private set; }

        public AuthenticationSystem(IAuthenticationManager authenticationManager)
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            AuthenticationManager = authenticationManager;
        }

        public async Task<bool> IsUserRegistered(string userName, string password)
        {
            var user = await UserManager.FindAsync(userName, password);
            return user != null;
        }

        public async Task<bool> CreateWithoutSignInAsync(string userName, string password)
        {
            var user = new ApplicationUser() { UserName = userName };
            var result = await UserManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task SignInAsync(string userName, string password, bool isPersistent)
        {
            var user = await UserManager.FindAsync(userName, password);
            if (user != null)
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignIn(new AuthenticationProperties() {IsPersistent = isPersistent}, identity);
            }
        }

        public async Task<bool> CreateAndSignInAsync(string userName, string password, bool isPersistent)
        {
            var user = new ApplicationUser() { UserName = userName };
            var result = await UserManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await SignInAsync(userName, password, isPersistent);
                return true;
            }
            return false;
        }

    }
}