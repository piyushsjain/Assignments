using ReimbursementPortal.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.DataAccessLayer.IRepository
{
    public interface IAdminRepository
    {
        Task<int> ApproveReimbursement(ReimbursementEntity reimbursement, int id);
        Task<List<ReimbursementEntity>> ReimbursementByRequestedPhase(string requestedPhase);
        Task<int> declineReimbursement(ReimbursementEntity reimbursement, int id);

    }
}
