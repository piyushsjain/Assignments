using Microsoft.AspNetCore.Identity;
using ReimbursementPortal.DataAccessLayer.Entities;
using ReimbursementPortal.DataAccessLayer.IRepository;
using ReimbursementPortal.SharedLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.DataAccessLayer.Repository
{
    public class AccountRepository :IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _loginManager;

        /// <summary>
        /// Constructer
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="loginManager"></param>
        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> loginManager)
        {
            _userManager = userManager;
            _loginManager = loginManager;
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, SignupEntity SignupEntity)
        {
            var result = await _userManager.CreateAsync(user, SignupEntity.Password);
            return result;
        }

        /// <summary>
        /// used to login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public async Task<SignInResult> PasswordLoginAsync(LoginEntity loginModel)
        {
            var result = await _loginManager.PasswordSignInAsync(loginModel.EmailAddress, loginModel.Password, false, false);
            return result;
        }
    }
}
