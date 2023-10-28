using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webnet.Models;
using System.Text.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using static webnet.Controllers.HomeController;
using System.Drawing.Drawing2D;
using System;  
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Numerics;
using System.Security.Policy;
using System.Runtime.CompilerServices;

namespace webnet.Controllers
{
    public class HomeController : Controller
    {
        public WebContext db;
        public HomeController(WebContext context)
        {
            db = context;
        }
        public IActionResult Index() => View();

        public IActionResult Reviews() => View();

        public IActionResult Page1() => View();

        public IActionResult Page2() => View();

        public IActionResult Page3() => View();

        public IActionResult Page4() => View();

        public IActionResult Page5() => View();

        public IActionResult Contacts() => View();
        public IActionResult Registration() => View();
        [HttpGet]
        public IActionResult Catalog() => View(db.Good.ToList());
        public IActionResult Login()
        {
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber && myNumber != 0)
            {
                return RedirectToAction("Profile");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Auth(string Email, string Password)
        {
            var user = db.User.FirstOrDefault(u => u.Email == Email && u.Password == Password);
            if (user != null)
            {
                TempData["myNumber"] = user.UserId;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Неверный email или пароль");
                return View("Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Regist(Users model)
        {
            if (ModelState.IsValid) 
            {
                if (db.User.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "Такой email уже зарегистрирован.");
                    return View(model);
                }
                var newUser = new Users
                {
                    Name = model.Name,
                    Password = model.Password,
                    Email = model.Email,
                    BirthDate = model.BirthDate.Date
                };
                db.User.Add(newUser);
                db.SaveChanges();
                TempData["myNumber"] = newUser.UserId;
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult GetProductInfo(int goodId)
        {
            var goods = db.Good.Where(g => g.GoodId == goodId).ToList();

            var productInfoList = goods.Select(good => new
            {
                Name = good.GoodName,
                Image = good.GoodImage,
                Price = good.GoodPrice,
                OldPrice = good.GoodOldPrice,
                Discount = good.GoodDiscount,
                Description = good.GoodDescription,
                ShortDescription = good.GoodShortDescription,
                Type = good.ProductType,
                Volume = good.ProductVolume,
                Category = good.ProductCategory,
                Country = good.ProductCountry,
                DopCharact = good.ProductDopCharact
            }).ToList();

            var productInfoJson = JsonSerializer.Serialize(productInfoList);
            return Content(productInfoJson, "application/json");
        }

    }

}