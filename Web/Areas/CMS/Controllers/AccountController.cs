using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DAL;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utilities.Helpers;
using Web.Areas.CMS.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Web.Areas.CMS.Controllers
{
    [Area("CMS")]
    public class AccountController : Controller
    {
        private readonly MainContext _context;

        public AccountController(MainContext context)
        {
            _context = context;
        }
        [Route("/cms")]
        [Route("/cms/hesab/giris")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [Route("/cms")]
        [Route("/cms/hesab/giris")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            User userFromDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginVM.Email.Trim().ToLower());

            if (userFromDb == null)
            {
                ModelState.AddModelError("", "Email və ya şifrə doğru deyil !");
                return View(loginVM);
            }

            if (!HashHelper.VerifyPasswordHash(loginVM.Password, userFromDb.SecretKey, userFromDb.PasswordHash))
            {
                ModelState.AddModelError("", "Email və ya şifrə doğru deyil !");
                return View(loginVM);
            }

            SetIdentity(userFromDb);
            return RedirectToAction("Index", "Home");
        }
        
        [Route("/cms/hesab/cixis")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }





        #region ---------User Security
        public User GetUser()
        {
            List<Claim> useridentity = GetIdentitiy();
            if (useridentity == null)
                return null;
            if (useridentity.FirstOrDefault(x => x.Type == "id") == null)
                return null;
            Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
            User user = _context.Users.Where(x => x.Id == userid).FirstOrDefault();
            return user;
        }
        public void SetIdentity(User user) 
        {
            var claims = new List<Claim> {                
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim("id",user.Id.ToString())
            };
            var userIdentity = new ClaimsIdentity(claims, "Admin");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            HttpContext.SignInAsync(principal);

        }
        public List<Claim> GetIdentitiy() 
        {
            List<Claim> checkuser = User.Claims.ToList();
            if (checkuser != null)
                return checkuser;
            return null;
        }
        
        #endregion ----------User Security

        public bool IsAjaxRequest(HttpRequest request)
        {
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}
