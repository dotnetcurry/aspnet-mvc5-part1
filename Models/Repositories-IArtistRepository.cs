using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Michaels_Stuff.Models.Repositories
{
    public interface IArtistRepository
    {
        Artist GetByID(Int32 id);
        List<Artist> GetByArtistId(Int32 artistID);
        List<Artist> GetAll();
        void Create(Artist artist);
        void Update(Artist artist);
        void Delete(Artist artist);
    }
}