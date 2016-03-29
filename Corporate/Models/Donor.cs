using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Models
{
    public class Donor
    {
        public int? DonorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool EmailUpdateFlag { get; set; }
        public string Employer { get; set; }
        public string Occupation { get; set; }
        public string OccupationStatus { get; set; }

        public Donor()
        {

        }
    }
}
