using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShop.Services;
using MovieShop.Entities;
using System.Web.Mvc;
using MovieShop.Utility.Validations;

namespace MovieShopMVC.Controllers
{
    [RoutePrefix("Users")]
    public class UserController : Controller
    {
        private UserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.InsertNewUser(user);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}