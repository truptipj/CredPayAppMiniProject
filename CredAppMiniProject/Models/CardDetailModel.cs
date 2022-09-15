using System;
using System.ComponentModel.DataAnnotations;

namespace CredAppMiniProject.Models
{
    public class CardDetailModel
    {
        public int CardDetailId { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string CardOwnerName { get; set; }

        public string UserId { get; set; }

        [Required]
        public int Balace { get; set; }

        [Required]
        public string Bank { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public int cvv { get; set; }

        public int createdBy { get; set; }
    }
}
