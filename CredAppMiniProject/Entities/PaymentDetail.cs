using CredAppMiniProject.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CredAppMiniProject.Entities
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentDetailId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("CardDetail")]
        public int CardDetailId { get; set; }
        public CardDetail CardDetail { get; set; }

        [ForeignKey("Pay")]
        public int PayId { get; set; }
        public Pay Pay { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        [Required, DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
