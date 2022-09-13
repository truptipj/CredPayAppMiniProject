using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Models
{
    public class PaymentDetailModel
    {
        [Required]
        public int PaymentDetailId { get; set; }

        [Required]
        public string CardNumber { get; set; }
        public int PayId { get; set; }
        public int createdBy { get; set; }
    }
}
