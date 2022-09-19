using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Models
{
    public class PaymentDetailsModelInfo
    {
        public string UserId { get; set; }

        public int AmountPaid { get; set; }

        public string CardNumber { get; set; }

        public int MinDue { get; set; }


        public string ProductName { get; set; }

         public int Price { get; set; }
        public int Balance { get; set; }
        public string Category { get; set; }
        public string Bank { get; set; }
        public DateTime Date { get; set; }
        public int PayId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        [Required, DefaultValue(true)]
        public bool IsActive { get; set; }

        public int CardDetailId { get; set; }
        
        public bool Status { get; set; }

    }
}
