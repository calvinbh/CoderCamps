using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Reviews.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public string RestaurantName { get; set; }

        public int RestaurantId { get; set; }

        public string Review { get; set; }

        public string Author { get; set; }

        public int Stars
        {
            get
            {
                return _stars;
            }
            set
            {
                if (value > 5)
                    _stars = 5;
                else if (value < 1)
                    _stars = 1;
                else
                    _stars = value;
            }
        }

        private int _stars
        {
            get;
            set;
        }

        public Rating()
        {
        }
    }
}