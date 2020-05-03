using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VO.DVDCentral.BL;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.MVCUI.ViewModels
{
    public class MovieGenresDirectorsRatingsFormats
    {
        public DVDCentral.BL.Models.Movie Movie { get; set; }
        public List<Genre> GenreList { get; set; }
        public List<Rating> RatingList { get; set; }
        public List<Format> FormatList { get; set; }
        public List<Director> DirectorList { get; set; }
        public IEnumerable<int> GenreIds { get; set; }
        
    }
}