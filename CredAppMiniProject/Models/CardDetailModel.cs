using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Models
{
    public class CardDetailModel
    {
        [Required]
        public int CardDetailId { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string CardOwnerName { get; set; }

        //[Required]
        //public string AddMoney { get; set; }
        public string UserId { get; set; }
        [Required]
        public int Balace { get; set; }

        [Required]
        public string Bank { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public int cvv { get; set; }
        //public int BankId { get; set; }
        public int createdBy { get; set; }
    }
}
