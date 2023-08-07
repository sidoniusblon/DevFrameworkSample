using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Account
        public string Login(string username, string password)
        {
            var user = _userService.GetUserByUserNameAndPassword(username, password);
            var roles = _userService.GetUserRoles(user).Select(x => x.RoleName).ToArray();

            if (user != null)
            {
                Debug.WriteLine("T" + roles[0]);
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(), user.UserName, user.Email, DateTime.Now.AddDays(2),roles, false, user.FirstName, user.LastName);
                return "User is authenticated";
            }
            return "User is not authenticated";
        }
    }
}