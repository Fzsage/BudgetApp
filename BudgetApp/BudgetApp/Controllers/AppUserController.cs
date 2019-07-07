using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserRegAPI.Models;

namespace UserRegAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public AppUserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        //POST /api/AppUser/Register
        public async Task<Object> PostAppUser(AppUserModel inpt)
        {
            var appUser = new AppUser()
            {
                UserName = inpt.UserName,
                Email = inpt.Email,
                FullName = inpt.FullName
            };

            try
            {
                var result =await _userManager.CreateAsync(appUser, inpt.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}