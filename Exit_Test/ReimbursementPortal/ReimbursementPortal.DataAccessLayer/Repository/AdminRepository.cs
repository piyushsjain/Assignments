using Microsoft.EntityFrameworkCore;
using ReimbursementPortal.DataAccessLayer.Data;
using ReimbursementPortal.DataAccessLayer.Entities;
using ReimbursementPortal.DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.DataAccessLayer.Repository
{
    public class AdminRepository :IAdminRepository
    {
        private readonly ReimbursementContext _reimbursementContext;

        public AdminRepository(ReimbursementContext reimbursementContext)
        {
            _reimbursementContext = reimbursementContext;            
        }

        public async Task<int> ApproveReimbursement(ReimbursementEntity reimbursement, int id)
        {
            var result = await _reimbursementContext.Reimbursements.FindAsync(id);


            result.ApprovedBy = reimbursement.ApprovedBy;
            result.ApprovedValue = reimbursement.ApprovedValue;
            result.RequestedPhase = "Approved";
            result.InternalNotes = reimbursement.InternalNotes;

            await _reimbursementContext.SaveChangesAsync();

            return result.Id;
        }

        public async Task<List<ReimbursementEntity>> ReimbursementByRequestedPhase(string requestedPhase)
        {
            return await _reimbursementContext.Reimbursements.Where(ReimbursementModel => ReimbursementModel.RequestedPhase == requestedPhase).ToListAsync();
        }

        public async Task<int> declineReimbursement(ReimbursementEntity reimbursement, int id)
        {
            var result = await _reimbursementContext.Reimbursements.FindAsync(id);


            result.RequestedPhase = "Declined";
            await _reimbursementContext.SaveChangesAsync();

            return result.Id;
        }
    }
}
