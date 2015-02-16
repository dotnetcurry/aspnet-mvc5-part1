using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Michaels_Stuff.Models
{

    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        [Display(Name = "Last Name", AutoGenerateFilter = false)]
        public string LastName { get; set; }
        [Display(Name = "First Name", AutoGenerateFilter = false)]
        public string FirstName { get; set; }
        [Display(Name = "Band Name", AutoGenerateFilter = false)]
        public String BandName { get; set; }
        [Display(Name = "First on Music Scene", AutoGenerateFilter = false)]
        public DateTime FirstOnSeen { get; set; }
         [JsonIgnore]
        public virtual ICollection<Publication> Publications { get; set; }
    }

 

   


}