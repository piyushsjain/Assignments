using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ReimbursementPortal.DataAccessLayer.Entities;
using ReimbursementPortal.DataAccessLayer.IRepository;
using ReimbursementPortal.SharedLayer.DataTransferObjects;
using ReimbursementPortal.SharedLayer.IServices;

namespace ReimbursementPortal.BusinessLayer.Services
{
    public class ReimbursementServices : IReimbursementServices
    {
        private readonly IReimbursementRepository _reimbursementRepository;
        private readonly IUserService _userService;

        public ReimbursementServices(IReimbursementRepository reimbursementRepository, IUserService userService)
        {
            _reimbursementRepository = reimbursementRepository;
            _userService = userService;
        }

        public async Task<int> AddReimbursement(ReimbursementDTO reimbursement)
        {
            //Conversion EventDTO to EventEntity
            var newReimbursement = new ReimbursementEntity()
            {
                Date = reimbursement.Date,
                ReimbursementType = reimbursement.ReimbursementType,
                RequestedValue = reimbursement.RequestedValue,
               Currency = reimbursement.Currency,
                RequestedPhase = "Pending",
                ReceiptAttached = "No",
                ApprovedValue = reimbursement.ApprovedValue,
                EmailAddress = reimbursement.EmailAddress
            };

            await _reimbursementRepository.AddReimbursement(newReimbursement);
            return newReimbursement.Id;
        }

        /// <summary>
        /// Used to get the particular event for a particlar user by using user id
        /// </summary>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public async Task<List<ReimbursementDTO>> GetReimbursementByEmailAddress(string emailAddress)
        {
            List<ReimbursementDTO> reimbursementListDTO = new List<ReimbursementDTO>();

            var myReimbursementList = await _reimbursementRepository.ReimbursementByEmailAddress(emailAddress);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReimbursementEntity, ReimbursementDTO>());
            var mapper = config.CreateMapper();
            reimbursementListDTO = mapper.Map<List<ReimbursementEntity>, List<ReimbursementDTO>>(myReimbursementList);
            return reimbursementListDTO;

        }

        /// <summary>
        /// Used to get the event details By using Event id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReimbursementDTO> ReimbursementDetailsById(int id)
        {
            ReimbursementEntity ReimbursementData = await _reimbursementRepository.GetReimbursementDetailsById(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReimbursementEntity, ReimbursementDTO>());
            var mapper = config.CreateMapper();
            ReimbursementDTO ReimbursementDataDTO = mapper.Map<ReimbursementEntity, ReimbursementDTO>(ReimbursementData);
            return ReimbursementDataDTO;
        }

        public async Task<int> EditReimbursement(ReimbursementDTO reimbursement, int id)
        {
            var editReimbursement = new ReimbursementEntity()
            {
                Date = reimbursement.Date,
                ReimbursementType = reimbursement.ReimbursementType,
                RequestedValue = reimbursement.RequestedValue,
                Currency = reimbursement.Currency,
                RequestedPhase = "Pending",
                ReceiptAttached = "No",
                ApprovedValue = reimbursement.ApprovedValue,
               
            };
            await _reimbursementRepository.EditReimbursement(editReimbursement, id);

            return editReimbursement.Id;
        }

        public async Task DeleteReimbursement(int id)
        {
            await _reimbursementRepository.DeleteReimbursement(id);
 
        }

        public async Task<List<ReimbursementDTO>> GetAllReimbursements()
        {
            List<ReimbursementDTO> reimbursementListDTO = new List<ReimbursementDTO>();

            var newList = await _reimbursementRepository.GetAllReimbursements();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReimbursementEntity, ReimbursementDTO>());
            var mapper = config.CreateMapper();
            reimbursementListDTO = mapper.Map<List<ReimbursementEntity>, List<ReimbursementDTO>>(newList);
            return reimbursementListDTO;
        }

        
    }

}
