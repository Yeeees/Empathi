using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MpathY.Models
{
    //Define the multi-select request.
    public class SearchByTypeReq
    {
        //public List<string> typeList { get; set; }
        public bool Monetary_Job { get; set; }
        public bool Volunteer { get; set; }
        public bool English_Education { get; set; }
        public bool Health { get; set; }
        public bool Accommodation { get; set; }
        public bool Legal_Service { get; set; }
        public bool Personal_Care_Food { get; set; }
        public bool Drug_alcohol_Counselling { get; set; }
        public bool Humanitarian_Settlement { get; set; }

    }
}