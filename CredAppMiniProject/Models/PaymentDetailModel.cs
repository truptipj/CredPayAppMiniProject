using System;
using System.ComponentModel.DataAnnotations;

namespace CredAppMiniProject.Models
{
    public class PaymentDetailModel
    {
        public int PaymentDetailId { get; set; }
        public int CardDetailId { get; set; }
        public int PayId { get; set; }
        public string UserId { get; set; }
        public int createdBy { get; set; }

        [Required]
        public DateTime Date { get; internal set; }
    }
}
