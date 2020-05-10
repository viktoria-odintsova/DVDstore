using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO.DVDCentral.BL.Models
{
    public class ShoppingCart
    {
        public List<Movie> Items { get; set; }
        public int TotalCount { get { return Items.Count; } }
        public double TotalCost { get { return Items.Sum(i => i.Cost); } }

        public ShoppingCart()
        {
            Items = new List<Movie>();
        }

        public void Add(Movie movie)
        {
            Items.Add(movie);
        }

        public void Remove(Movie movie)
        {
            Items.Remove(movie);
        }

        public void Checkout()
        {
            Items = new List<Movie>();
        }
    }
}
