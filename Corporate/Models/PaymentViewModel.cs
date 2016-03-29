using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Models
{
    public class PaymentViewModel
    {
        public int DonationID { get; set; }
        public Donation Donation { get; set; }
        public int DonorID { get; set; }
        public Donor Donor { get; set; }
    }
}
