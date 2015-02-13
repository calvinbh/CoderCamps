using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Reviews.Models
{
    public class Db
    {
        public List<Restaurant> Restaurants { get; set; }

        public static Db Instance
        {
            get
            {
                return _instance ?? (_instance = CreateDb());
            }
        }

        private static Db _instance;

        private static Db CreateDb()
        {
            return new Db()
            {
                //seed our properties
                Restaurants = new List<Restaurant>() {
                    new Restaurant("Li Wah", "Cleveland", "Ohio", "http://liwahrestaurant.com/sitebuildercontent/sitebuilderpictures/.pond/LW3.jpg.w300h225.jpg",0,new List<string> {"Chinese","Cheap"}),
                    new Restaurant("Cochon Butcher", "New Orleans", "Louisiana", "http://www.cochonbutcher.com/wp-content/themes/Cochon-Butcher/images/gallery07.jpg",1,new List<string> {"Hipster","Local Sourced"}),
                    new Restaurant("Ruth's Chris Steak House", "Salt Lake City", "Utah","http://orlandofoodscene.com/wp-content/uploads/2013/02/ruthschrissteakhouse.jpg",2, new List<string>{"Steakhouse","Fancy"})
                }
            };
        }

        private Db()
        {
        }
    }
}