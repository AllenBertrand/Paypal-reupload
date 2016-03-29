using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Models
{
    public class Donation
    {
        public int DonationID { get; set; }
        public int? DonorID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Confirmation { get; set; }
        public bool? SuccessFlag { get; set; }


        public Donation()
        {
        }
    }
}
