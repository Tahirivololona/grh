using GRH_BO.Dto.User;
using GRH_BS.User;
using GRH_UI.Models.Login;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GRH_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBaseService _userService;

        public HomeController (IBaseService userService)
        {
            _userService = new BaseService();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                UserDto userDto = new UserDto
                {
                    Email=model.Email,
                    Password=model.Password
                };
                var user = _userService.Login(userDto);
                return RedirectToAction("Accueil");
            }
            catch(Exception ex)
            {
                
                ViewBag.ErrorMessage= ex.Message;
                model.ErrorMessage = ex.Message;
                return View(model);
            }
            
        }

        public ActionResult Accueil()
        {
            return View();
        }
    }
}