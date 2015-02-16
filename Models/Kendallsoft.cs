using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Michaels_Stuff.Models
{
    public class Kendallsoft
    {
        [Key]
        public int Companyid { get; set; }
        public String CompanyName { get; set; }
        public String CEO { get; set; }

    }
}