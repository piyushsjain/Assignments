using Microsoft.AspNetCore.Http;
using ReimbursementPortal.SharedLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.BusinessLayer.Services
{
    public class UserService : IUserService
    {
            private readonly IHttpContextAccessor _httpContext;
            public UserService(IHttpContextAccessor httpContext)
            {
                _httpContext = httpContext;
            }

            /// <summary>
            /// Used to get user id of current user
            /// </summary>
            /// <returns></returns>
            public string GetUserID()
            {
                return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            }


       
    }
}
