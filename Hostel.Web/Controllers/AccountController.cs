using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Hostel.BusinessLogic.Models;
using Hostel.BusinessLogic.Services;

using Hostel.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.Web.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IAccount _acount;
        private readonly IMapper _mapper;
        public AccountController(IAccount acount, IMapper mapper)
        {
            _acount = acount;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Models.LoginModel model)
        {
            if (ModelState.IsValid)
            {

                var client = _acount.Login(_mapper.Map<BusinessLogic.Models.LoginModel>(model));
                if (client != null)
                {
                    var clientWeb = new ClientWebView
                    {
                        Email = client.Email,
                        Password = client.Password,
                        idRole = client.idRole
                    };
                    await Authenticate(clientWeb); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ClientWebView model)
        {
            if (ModelState.IsValid)
            {
                model.idRole = 1;
                if (_acount.Register(_mapper.Map<ClientFullInformation>(model)))
                {
                    // добавляем пользователя в бд
                    
                    
                    await Authenticate(model); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(ClientWebView  model)
        {
            // создаем один claim
           
             var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, model.Email),        
                new Claim(ClaimsIdentity.DefaultRoleClaimType, ((RoleType)model.idRole).ToString())
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }



    }
}
