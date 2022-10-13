using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReimbursementPortal.PresentationLayer.Models;
using ReimbursementPortal.SharedLayer.DataTransferObjects;
using ReimbursementPortal.SharedLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementPortal.PresentationLayer.Controllers
{
    [Route("apiAdmin/[Controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminServices _adminService;


        public AdminController(IAdminServices adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("{reimbursementId}")]
        public async Task<JsonResult> ApproveReimbursement(ReimbursementViewModel reimbursement, int reimbursementId)
        {

            var approveReimbursement = new ReimbursementDTO()
            {

                ApprovedBy = reimbursement.ApprovedBy,
                ApprovedValue = reimbursement.ApprovedValue,
                RequestedPhase = "Approved",
                InternalNotes = reimbursement.InternalNotes,

            };

            await _adminService.ApproveReimbursement(approveReimbursement, reimbursementId);

            return Json(new { success = true });


        }

        [Route("declineReimbursement" + "/{reimbursementId}")]
        [HttpPost]
        public async Task<JsonResult> DeclineReimbursement(ReimbursementViewModel reimbursement, int reimbursementId)
        {

            var approveReimbursement = new ReimbursementDTO()
            {
                RequestedPhase = "Declined"               
            };

            await _adminService.declineReimbursement(approveReimbursement, reimbursementId);

            return Json(new { success = true });


        }

        [HttpGet("{id}")]
        public async Task<List<ReimbursementViewModel>> GetReimbursements(string id)
        {
            //Get Current user 
            var requestedPhase = id;

            List<ReimbursementDTO> ReimbursementListDTO = await _adminService.GetReimbursementByRequestedPhase(requestedPhase);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReimbursementDTO, ReimbursementViewModel>());
            var mapper = config.CreateMapper();
            List<ReimbursementViewModel> myReimbursements = mapper.Map<List<ReimbursementDTO>, List<ReimbursementViewModel>>(ReimbursementListDTO);

            return myReimbursements;
        }
    }
}
