using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MpathY.Models;

namespace MpathY.ViewModels
{
    public class ClassificationOrgModel
    {
        public Organisation Org { get; set; }
        public List<Classification> Type { get; set; }
    }
}