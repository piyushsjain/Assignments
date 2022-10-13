using ReimbursementPortal.SharedLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.SharedLayer.IServices
{
    public interface IAdminServices
    {
        Task<List<ReimbursementDTO>> GetReimbursementByRequestedPhase(string requestedPhase);
        Task<int> ApproveReimbursement(ReimbursementDTO reimbursement, int id);
        Task<int> declineReimbursement(ReimbursementDTO reimbursement, int id);

    }
}
