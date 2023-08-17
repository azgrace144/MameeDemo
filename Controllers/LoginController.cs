using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppOwnsData.DB;
using AppOwnsData.Models;
using AppOwnsData.Respositories;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Hosting.Server;
using Newtonsoft.Json;

namespace AppOwnsData.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbcontext _context;
        private readonly ILogin _loginUser;

        public LoginController(AppDbcontext context,ILogin loguser)
        {
            _context = context;
            _loginUser = loguser;
        }

        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(string email, string passcode)
        {
            var issuccess = _loginUser.AuthenticateUser(email, passcode);

            if (issuccess.Result != null)
            {

                TempData["email"] = email;

                ViewBag.username = string.Format("Successfully logged-in", email);
            
                return RedirectToAction("Index","Home", new { email = email });
            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", email);
                return View();
            }
        }

    }
}
