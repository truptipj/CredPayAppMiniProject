using CredAppMiniProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Entities
{
    public class PaymentDetail
    {
        [Key]
        [Required]
        public int PaymentDetailId { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [ForeignKey("Pay")]
        public int PayId { get; set; }
        public Pay Pay { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        [Required, DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
