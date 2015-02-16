using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Michaels_Stuff.Models
{
    public class Publication
    {
        [Key]
        public int PublicationId { get; set; }
        public int ArtistId { get; set; }
        public int MediaId { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateReleased { get; set; }
        [JsonIgnore]
        public  virtual Artist Artist { get; set; }
        [JsonIgnore]
        public virtual MediaRelease MediaRelease { get; set; }
    }
}