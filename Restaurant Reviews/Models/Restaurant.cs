using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Reviews.Models
{
    public class Restaurant
    {
        public string Name { get; set; }

        public float AverageStars { get; set; }

        public string CuisineTagsRaw { get; set; }

        public List<string> CuisineTags { get; set; }

        public List<Rating> Ratings { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string LogoUrl { get; set; }

        public int Id { get; set; }

        public int ReviewCount { get; set; }

        public Restaurant(string name, string city, string state, string logoUrl, int id, List<string> cuisinetags)
        {
            Name = name;
            City = city;
            State = state;
            LogoUrl = logoUrl;
            ReviewCount = 0;
            Id = id;
            CuisineTags = cuisinetags;
            Ratings = new List<Rating>();
            AverageStars = 0;
        }

        public void UpdateAverage()
        {
            float sum = 0f;
            for (var i = 0; i < Ratings.Count; i++)
            {
                sum += Ratings[i].Stars;
            }
            AverageStars = sum / Ratings.Count;
            ReviewCount = Ratings.Count;
        }

        public Restaurant()
        {
        }
    }
}