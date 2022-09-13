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
    public class CardDetail
    {
        [Key]

        [Required]
        public int CardDetailId { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string CardOwnerName { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public int cvv { get; set; }

        [Required]
        public int Balace { get; set; }


        [Required]
        public string Bank { get; set; }

        //public int BankId { get; set; }

        //Foreign key for Bank
        //public int? BankId { get; set; }

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
