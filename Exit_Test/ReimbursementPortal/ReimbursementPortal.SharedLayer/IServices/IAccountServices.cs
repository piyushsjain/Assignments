using Microsoft.AspNetCore.Identity;
using ReimbursementPortal.SharedLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.SharedLayer.IServices
{
    public interface IAccountServices
    {
        Task<IdentityResult> CreateUserAsync(SignupDTO userModel);
        Task<SignInResult> LoginUserAsync(LoginDTO loginModel);
    }
}
