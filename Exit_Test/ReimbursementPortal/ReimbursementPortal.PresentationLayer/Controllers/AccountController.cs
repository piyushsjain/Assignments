using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReimbursementPortal.PresentationLayer.Models;
using ReimbursementPortal.SharedLayer.DataTransferObjects;
using ReimbursementPortal.SharedLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementPortal.PresentationLayer.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountService;

        public AccountController(IAccountServices accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Register Method Used to Register the user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
     // [Route("Signup")]
        [HttpPost]
        public async Task<JsonResult> Signup(SignupViewModel userModel)
        {
            if (ModelState.IsValid)
            {


                var user = new SignupDTO()
                {
                    FullName = userModel.FullName,
                    EmailAddress = userModel.EmailAddress,
                    PanNumber = userModel.PanNumber,
                    Bank = userModel.Bank,
                    BankNumber=userModel.BankNumber,
                    Password = userModel.Password,
                    ConfirmPassword = userModel.ConfirmPassword
                };
                var result = await _accountService.CreateUserAsync(user);

                if (!result.Succeeded)
                {

                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return Json(new
                    {
                        success = false,
                        errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                             .Select(m => m.ErrorMessage).ToArray()
                    });

                }
                //If User successfully Ragister in the portel so redirect into the Login Page
                return Json(new { success = true });

            }

            return Json(new { success = false });
        }

        /// <summary>
        /// Login method Used to Login the user
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [Route("Login")]
        [HttpPost]
        public async Task<JsonResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
               
                var user = new LoginDTO()
                {
                    EmailAddress = loginModel.EmailAddress,
                    Password = loginModel.Password,                
                };
                var result = await _accountService.LoginUserAsync(user);

                //if User successfully login in the portel so redirect into the Home Page Otherwise Invaild Credentials
                if (result.Succeeded)
                {
                    return Json(new { success = true});
                }
                ModelState.AddModelError("", "Invaild Credentials");
            }
            return Json(new { success = "false",
                errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                             .Select(m => m.ErrorMessage).ToArray()
            });
        }
    }
}

