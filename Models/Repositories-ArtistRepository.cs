using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Michaels_Stuff.Models.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {


        public List<Artist> GetByArtistId(int artistID)
        {
            return Set.Where(s => s.ArtistId == artistID).ToList();
        }
    }
}