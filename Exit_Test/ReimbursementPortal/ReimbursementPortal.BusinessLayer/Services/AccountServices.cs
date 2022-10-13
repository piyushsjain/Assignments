using Microsoft.AspNetCore.Identity;
using ReimbursementPortal.SharedLayer.DataTransferObjects;
using System.Threading.Tasks;
using ReimbursementPortal.DataAccessLayer.Entities;
using ReimbursementPortal.DataAccessLayer.IRepository;
using ReimbursementPortal.SharedLayer.IServices;

namespace ReimbursementPortal.BusinessLayer.Services
{
    public class AccountServices :IAccountServices
    {
        private readonly IAccountRepository _accountRepository;

        public AccountServices(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        /// <summary>
        /// Used to create the user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateUserAsync(SignupDTO userModel)
        {
            //Conversion RegisterDTO to Application User
            var user = new ApplicationUser()
            {
                FullName = userModel.FullName,
                PanNumber=userModel.PanNumber,
                Bank=userModel.Bank,
                BankNumber = userModel.BankNumber,
                Email = userModel.EmailAddress,
                UserName = userModel.EmailAddress,

            };
            //Conversion RegisterDTO to Register Entity
            
            var userModelEntity = new SignupEntity()
            {
                FullName = userModel.FullName,
                EmailAddress = userModel.EmailAddress,
                PanNumber = userModel.PanNumber,
                Bank = userModel.Bank,
                Password = userModel.Password,
                ConfirmPassword = userModel.ConfirmPassword


            };

            var id = await _accountRepository.CreateUserAsync(user, userModelEntity);
            return id;
        }

        /// <summary>
        /// used to login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public async Task<SignInResult> LoginUserAsync(LoginDTO loginModel)
        {
            ////Conversion LoginDTO to LoginEntity
            var user = new LoginEntity()
            {
                EmailAddress = loginModel.EmailAddress,
                Password = loginModel.Password,               
            };
            var result = await _accountRepository.PasswordLoginAsync(user);

            return result;
        }

    }
}
