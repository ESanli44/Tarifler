using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tarifler.Core.Entity;
using Tarifler.Service.Abstract;
using Tarifler.Web.Models;

namespace Tarifler.Web.Controllers
{
    
        public class AccountController : Controller
        {
            private readonly IMapper _mapper;
            private readonly IService<User> _serviceUser;

            public AccountController(IService<User> serviceUser, IMapper mapper)
            {
                _serviceUser = serviceUser;
                _mapper = mapper;
            }
            //---------------------------------Index----------------------------------
            [Authorize]
            public async Task<IActionResult> Index()
            {
                var kullanicilar = await _serviceUser.GetAllAsync();
                return View(kullanicilar);
            }
            //------------------------------------Giriş--------------------------------------------
            [HttpGet]
            public IActionResult SignIn()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> SignIn(LoginViewModel model)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var kullanici = await _serviceUser.GetFirstAsync
                            (u => u.UserEmail == model.UserEmail && u.UserPassword == model.UserPassword);
                        if (kullanici == null)
                        {
                            ModelState.AddModelError("", "Kullanıcı Adı veya Parola Yanlış");
                        }
                        else
                        {
                            var claims = new List<Claim>()
                        {
                            new(ClaimTypes.Name,kullanici.FirstName),
                            new(ClaimTypes.Email,kullanici.UserEmail),
                            new("UserId",kullanici.UserId.ToString()), //Custom Yetki tanımlama
                        };

                            if (kullanici.IsAdmin == true)
                                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                            else if (kullanici.IsMember == true)
                                claims.Add(new Claim(ClaimTypes.Role, "Member"));
                            else
                                claims.Add(new Claim(ClaimTypes.Role, "Guest"));

                            var userIdentity = new ClaimsIdentity(claims, "Login"); //Login yetkilendirmesi
                            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity); //kimlik koleksiyonu
                            await HttpContext.SignInAsync(claimsPrincipal); //login

                            return Redirect(string.IsNullOrEmpty(model.ReturnUrl) ? "/" : model.ReturnUrl);
                        }
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Hata Oluştu: " + ex.Message.ToString());
                    }
                }
                return View(model);

            }
            //------------------------------------Kayıt-------------------------------
            [HttpGet]
            public IActionResult SignUp()
            {

                return View();
            }

            [HttpPost]
            public async Task<IActionResult> SignUp(UserViewModel model)
            {
                var user = _mapper.Map<User>(model);
                if (ModelState.IsValid)
                {
                    user.IsGuest = true;
                    await _serviceUser.AddAsync(user);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            //--------------------------Çıkış-------------------------------------------------------

            public async Task<IActionResult> SignOut()
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction("SignIn");
            }

            //-------------------------------Yetkisiz Kullanıcı sayfası----------------------------------
            [Route("AccessDenied")]
            public IActionResult AccessDenied()
            {
                return View();
            }
        }
}
