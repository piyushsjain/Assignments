using Microsoft.EntityFrameworkCore;
using ReimbursementPortal.DataAccessLayer.Data;
using ReimbursementPortal.DataAccessLayer.Entities;
using ReimbursementPortal.DataAccessLayer.IRepository;
using ReimbursementPortal.SharedLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.DataAccessLayer.Repository
{
    public class ReimbursementRepository : IReimbursementRepository
    {
        private readonly ReimbursementContext _reimbursementContext;
       // private readonly IUserService _userService;

        public ReimbursementRepository(ReimbursementContext reimbursementContext)
        {
            _reimbursementContext = reimbursementContext;
           // _userService = userService;
        }

        public async Task<int> AddReimbursement(ReimbursementEntity reimbursement)
        {

            await _reimbursementContext.Reimbursements.AddAsync(reimbursement);
            await _reimbursementContext.SaveChangesAsync();
            return reimbursement.Id;
        }

        public async Task<List<ReimbursementEntity>> ReimbursementByEmailAddress(string emailAddress)
        {
            return await _reimbursementContext.Reimbursements.Where(ReimbursementModel => ReimbursementModel.EmailAddress == emailAddress).ToListAsync();
        }

        public async Task<ReimbursementEntity> GetReimbursementDetailsById(int id)
        {
            return await _reimbursementContext.Reimbursements.FindAsync(id);

        }

        public async Task<int> EditReimbursement(ReimbursementEntity reimbursement, int id)
        {
            var result = await _reimbursementContext.Reimbursements.FindAsync(id);

            result.Date = reimbursement.Date;
            result.ReimbursementType = reimbursement.ReimbursementType;
            result.RequestedValue = reimbursement.RequestedValue;
            result.Currency = reimbursement.Currency;
            result.RequestedPhase = "Pending";
            result.ReceiptAttached = "No";
            result.ApprovedValue = reimbursement.ApprovedValue;
          
            await _reimbursementContext.SaveChangesAsync();

            return result.Id;
        }

        public async Task DeleteReimbursement(int id)
        {
            var result = await _reimbursementContext.Reimbursements.FindAsync(id);
            _reimbursementContext.Reimbursements.Remove(result);
            await _reimbursementContext.SaveChangesAsync();
        }
        public async Task<List<ReimbursementEntity>> GetAllReimbursements()
        {
            return await _reimbursementContext.Reimbursements.ToListAsync();
        }

       
    }
}
