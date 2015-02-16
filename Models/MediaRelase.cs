using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Michaels_Stuff.Models
{
    public class MediaRelease
    {
        [Key]
        public int MediaId { get; set; }
        public string MediaTitle { get; set; }
        //When serialization happens don't handle collections at this time
          [JsonIgnore]
        public virtual ICollection<Publication> Publications { get; set; }
    }
}