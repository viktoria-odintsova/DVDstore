using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VO.DVDCentral.BL;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.API.Controllers
{
    public class RatingController : ApiController
    {
        // GET: api/Rating
        public IEnumerable<Rating> Get()
        {
            List<Rating> ratings = RatingManager.Load();
            return ratings;
        }

        // GET: api/Rating/5
        public Rating Get(int id)
        {
            Rating rating = RatingManager.LoadById(id);
            return rating;
        }

        // POST: api/Rating
        public void Post([FromBody]Rating rating)
        {
            RatingManager.Insert(rating);
        }

        // PUT: api/Rating/5
        public void Put(int id, [FromBody]Rating rating)
        {
            RatingManager.Update(rating);
        }

        // DELETE: api/Rating/5
        public void Delete(int id)
        {
            RatingManager.Delete(id);
        }
    }
}
