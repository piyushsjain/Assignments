using Microsoft.AspNetCore.Identity;
using ReimbursementPortal.DataAccessLayer.Entities;
using ReimbursementPortal.SharedLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.DataAccessLayer.IRepository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, SignupEntity SignupEntity);
        Task<SignInResult> PasswordLoginAsync(LoginEntity loginModel);
    }
}
