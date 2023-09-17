using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLink.Core.Models
{
    public class Payment  : Entity
    {
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
        public Research Research { get; set; }
        public Guid ResearchId { get; set; }
        public DateTime  PaymentDate { get; set; }
        public string FWReference { get; set; }
        public string TransactionReference{ get; set; }
        public string TransactionId{ get; set; }
        public string PaymentMethod { get; set; }
        public string Currency {  get; set; }
        public string Status { get; set; }
    }
}
