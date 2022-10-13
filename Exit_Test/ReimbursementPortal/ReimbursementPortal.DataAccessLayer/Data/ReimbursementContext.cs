using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReimbursementPortal.DataAccessLayer.Entities;
using ReimbursementPortal.SharedLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.DataAccessLayer.Data
{
   public class ReimbursementContext :IdentityDbContext<ApplicationUser>
    {
        public ReimbursementContext(DbContextOptions<ReimbursementContext> options) : base(options)
        {

        }

        public DbSet<ReimbursementEntity> Reimbursements { get; set; }
      
    }
}
