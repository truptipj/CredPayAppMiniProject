using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Models
{
    public class PayModel
    {
        public int PayId { get; set; }
        public int AmountPaid { get; set; }
        public int MinDue { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string CardType { get; set; }
        public int CardDetailId { get; set; }
        public int createdBy { get; set; }
        
    }
}
