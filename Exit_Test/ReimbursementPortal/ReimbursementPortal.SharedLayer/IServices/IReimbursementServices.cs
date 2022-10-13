using ReimbursementPortal.SharedLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.SharedLayer.IServices
{
   public interface IReimbursementServices
    {
        Task<int> AddReimbursement(ReimbursementDTO reimbursement);
        Task<List<ReimbursementDTO>> GetReimbursementByEmailAddress(string emailAddress);
        Task<ReimbursementDTO> ReimbursementDetailsById(int id);
        Task<int> EditReimbursement(ReimbursementDTO reimbursement, int id);
        Task DeleteReimbursement(int id);
        Task<List<ReimbursementDTO>> GetAllReimbursements();
       
    }
}
