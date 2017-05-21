using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//for Required statement

namespace MpathY.Models
{
    //This class defines Organisation and all the attributes for each orgnasation object.
    public class Organisation
    {

        public int OrgId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public List<string> services = new List<string>();
        public string servicesLine = "";
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Services { get; set; }
        public string getServicesLine()
        {
            return servicesLine;
        }
        public List<string> getServices()
        {
            return services;
        }

    }
}