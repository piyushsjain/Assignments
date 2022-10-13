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
    [Route("apiReimbursement/[Controller]")]
    [ApiController]
    public class ReimbursementController : Controller
    {
        private readonly IReimbursementServices _reimbursementService;
        private readonly IUserService _userService;
        public ReimbursementController(IReimbursementServices reimbursementService, IUserService userService)
        {
            _reimbursementService = reimbursementService;
            _userService = userService;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<JsonResult> CreateEvent(ReimbursementViewModel reimbursementModel)
        {
            if (ModelState.IsValid)
            {
                //Conversion EventViewModel to EventDTO
                var reimbursement = new ReimbursementDTO()
                {
                    Date = reimbursementModel.Date,
                   ReimbursementType = reimbursementModel.ReimbursementType,
                    RequestedValue = reimbursementModel.RequestedValue,
                    Currency = reimbursementModel.Currency,
                    RequestedPhase = "Pending",
                    ReceiptAttached = "No",
                    ApprovedValue = reimbursementModel.ApprovedValue,
                    EmailAddress = reimbursementModel.EmailAddress
                };

                var result = await _reimbursementService.AddReimbursement(reimbursement);
                //if EventCreated Succefully
                if (result > 0)
                {
                    //return RedirectToAction(nameof(CreateEvent), new { isSuccess = true, eventId = result });
                    return Json(new { success = true });
                    //return NotFound();
                }
            }
            return Json(new { success = false });
            //return NotFound();

        }

        //[Route("myReimbursements")]
        [HttpGet("{id}")]
        public async Task<List<ReimbursementViewModel>> MyReimbursements(string id)
        {
            //Get Current user 
            var emailAddress = id;

            List<ReimbursementDTO> ReimbursementListDTO = await _reimbursementService.GetReimbursementByEmailAddress(emailAddress);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReimbursementDTO, ReimbursementViewModel>());
            var mapper = config.CreateMapper();
            List<ReimbursementViewModel> myReimbursements = mapper.Map<List<ReimbursementDTO>, List<ReimbursementViewModel>>(ReimbursementListDTO);

            return myReimbursements;
        }

        [Route("getReimbursement"+"/{reimbursementId}")]
        [HttpGet]
        public async Task<ReimbursementViewModel> ReimbursementDetails(int reimbursementId)
        {
            //Model Mapping
            ReimbursementViewModel data = new ReimbursementViewModel();
            var reimbursementModelDTO = await _reimbursementService.ReimbursementDetailsById(reimbursementId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReimbursementDTO, ReimbursementViewModel>());
            var mapper = config.CreateMapper();
            data = mapper.Map<ReimbursementDTO, ReimbursementViewModel>(reimbursementModelDTO);

            return data;
        }



        [HttpPost("{id}")]
        public async Task<JsonResult> EditReimbursement(ReimbursementViewModel reimbursement, int id)
        {
            if (ModelState.IsValid)
            {
                var editReimbursement = new ReimbursementDTO()
                {
                    Date = reimbursement.Date,
                    ReimbursementType = reimbursement.ReimbursementType,
                    RequestedValue = reimbursement.RequestedValue,
                    Currency = reimbursement.Currency,
                    RequestedPhase = "Pending",
                    ReceiptAttached = "No",
                    ApprovedValue = reimbursement.ApprovedValue,
                   
                };

                await _reimbursementService.EditReimbursement(editReimbursement, id);
                
                return Json(new { success = true });
                

            }
            return Json(new { success = false });

        }


        [HttpDelete("{id}")]
        public async Task DeleteReimbursement(int id)
        {
            await _reimbursementService.DeleteReimbursement(id);

        }

        [Route("allReimbursement")]
        [HttpGet]
        public async Task<List<ReimbursementViewModel>> GetALLEvents()
        {
            
            List<ReimbursementDTO> reimbursementListDTO = await _reimbursementService.GetAllReimbursements();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReimbursementDTO, ReimbursementViewModel>());
            var mapper = config.CreateMapper();
            List<ReimbursementViewModel> allReimbursements = mapper.Map<List<ReimbursementDTO>, List<ReimbursementViewModel>>(reimbursementListDTO);

            return allReimbursements;
            
        }

       
    }
}
