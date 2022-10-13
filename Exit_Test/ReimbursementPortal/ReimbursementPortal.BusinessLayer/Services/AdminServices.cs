using AutoMapper;
using ReimbursementPortal.DataAccessLayer.Entities;
using ReimbursementPortal.DataAccessLayer.IRepository;
using ReimbursementPortal.SharedLayer.DataTransferObjects;
using ReimbursementPortal.SharedLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.BusinessLayer.Services
{
   public class AdminServices : IAdminServices
    {
        private readonly IAdminRepository _adminRepository;

        public AdminServices(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<int> ApproveReimbursement(ReimbursementDTO reimbursement, int id)
        {
            var approveReimbursement = new ReimbursementEntity()
            {

                ApprovedValue = reimbursement.ApprovedValue,
                ApprovedBy = reimbursement.ApprovedBy,
                RequestedPhase = "Approved",
                InternalNotes = reimbursement.InternalNotes,

            };
            await _adminRepository.ApproveReimbursement(approveReimbursement, id);

            return approveReimbursement.Id;
        }

        public async Task<List<ReimbursementDTO>> GetReimbursementByRequestedPhase(string requestedPhase)
        {
            List<ReimbursementDTO> reimbursementListDTO = new List<ReimbursementDTO>();

            var myReimbursementList = await _adminRepository.ReimbursementByRequestedPhase(requestedPhase);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReimbursementEntity, ReimbursementDTO>());
            var mapper = config.CreateMapper();
            reimbursementListDTO = mapper.Map<List<ReimbursementEntity>, List<ReimbursementDTO>>(myReimbursementList);
            return reimbursementListDTO;

        }

        public async Task<int> declineReimbursement(ReimbursementDTO reimbursement, int id)
        {
            var approveReimbursement = new ReimbursementEntity()
            {              
                RequestedPhase = "Declined"

            };
            await _adminRepository.declineReimbursement(approveReimbursement, id);

            return approveReimbursement.Id;
        }

    }
}
