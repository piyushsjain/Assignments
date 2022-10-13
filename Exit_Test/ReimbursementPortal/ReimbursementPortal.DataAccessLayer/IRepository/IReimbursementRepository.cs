using ReimbursementPortal.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.DataAccessLayer.IRepository
{
    public interface IReimbursementRepository
    {
        Task<int> AddReimbursement(ReimbursementEntity reimbursement);
        Task<List<ReimbursementEntity>> ReimbursementByEmailAddress(string emailAddress);
        Task<ReimbursementEntity> GetReimbursementDetailsById(int id);
        Task<int> EditReimbursement(ReimbursementEntity reimbursement, int id);
        Task DeleteReimbursement(int id);
        Task<List<ReimbursementEntity>> GetAllReimbursements();
        
    }
}
