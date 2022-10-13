using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementPortal.SharedLayer.DataTransferObjects
{
    public class ReimbursementDTO :BaseReimbursementDTO
    {
        
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

       
        [Display(Name = "ReimbursementType")]
        public string ReimbursementType { get; set; }

       
        [Display(Name = "RequestedValue")]
        public float RequestedValue { get; set; }

        [Display(Name = "ApprovedValue ")]
        public float ApprovedValue { get; set; }

       
        [Display(Name = "Currency")]
        public string Currency { get; set; }

        [Display(Name = "Requested Phase")]
        public string RequestedPhase { get; set; }

        [Display(Name = "ReceiptAttached")]
        public string ReceiptAttached { get; set; }


        [Display(Name = "UploadImage")]
        [NotMapped]
        public IFormFile UploadImage { get; set; }
        public string EmailAddress { get; set; }
        public string ApprovedBy { get; set; }
        public string InternalNotes { get; set; }
    }
}
