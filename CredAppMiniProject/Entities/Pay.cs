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
    public class Pay
    {
        [Key]

        [Required]
        public int PayId { get; set; }

         [ForeignKey("CardDetail")]
        public int CardDetailId { get; set; }
  
        public CardDetail CardDetail { get; set; }

        public string ProductName { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string CardType { get; set; }

        [Required]
        public int AmountPaid { get; set; }

        [Required]
        public int MinDue { get; set; }

       // public ICollection<PaymentDetail> PaymentDetail { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        [Required, DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
