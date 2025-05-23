﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using REAL_EshopProjectHosperger.Database;
using REAL_EshopProjectHosperger.Entities;
using REAL_EshopProjectHosperger.Helpers;
using REAL_EshopProjectHosperger.Models.Auth;

namespace REAL_EshopProjectHosperger.Controllers
{
    public class AuthController : BaseController
    {
        private DatabaseContext _context;

        public AuthController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            Account? account = _context.Accounts.SingleOrDefault(a => a.Username == loginViewModel.Username);
            if (account == null || account.Password != SHA256Helper.HashPassword(loginViewModel.Password))
            {
                TempData["Message"] = "Špatný username nebo heslo!";
                TempData["MessageType"] = "danger";
                return View(loginViewModel);
            }

            HttpContext.Session.SetString("User", account.Username);
            HttpContext.Session.SetString("Role", account.Role);
            

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            // Create a new Account object
            Account newAccount = new Account
            {
                Username = registerViewModel.Username,
                Password = SHA256Helper.HashPassword(registerViewModel.Password),
                FirstName = registerViewModel.Firstname,
                LastName = registerViewModel.Lastname,
                Email = registerViewModel.Email
            };

            // Add the new account to the database
            _context.Accounts.Add(newAccount);
            _context.SaveChanges();

            TempData["Message"] = "Účet byl úspěšně vytvořen!";
            TempData["MessageType"] = "success";
            return View(new RegisterViewModel());
            
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            HttpContext.Session.Remove("Role");

            return RedirectToAction("Index", "Home");
        }
    }
}
