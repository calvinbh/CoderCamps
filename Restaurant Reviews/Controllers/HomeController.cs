using Restaurant_Reviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant_Reviews.Controllers
{
    public class HomeController : Controller
    {
        private Db db = Db.Instance;

        public ActionResult Index()
        {
            return View(db.Restaurants);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddRestaurant()
        {
            return View(new Restaurant());
        }

        [HttpPost]
        public ActionResult AddRestaurant(Restaurant model)
        {
            model.Id = db.Restaurants.Select(x => x.Id).LastOrDefault() + 1;
            model.CuisineTags = model.CuisineTagsRaw.Split(',').ToList();
            model.Ratings = new List<Rating>();
            model.AverageStars = 0;
            db.Restaurants.Add(model);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteRestaurant(int id = -1)
        {
            if (id != -1)
                if (db.Restaurants.Any(x => x.Id == id))
                {
                    Restaurant restaurant = db.Restaurants.Where(x => x.Id == id).FirstOrDefault();
                    db.Restaurants.Remove(restaurant);
                }
            return RedirectToAction("Index");
        }

        public ActionResult EditRestaurant(int id = -1)
        {
            Restaurant restaurant = db.Restaurants.Where(x => x.Id == id).FirstOrDefault();
            return View("AddRestaurant", restaurant);
        }

        [HttpPost]
        public ActionResult EditRestaurant(Restaurant x)
        {
            foreach (Restaurant restaurant in db.Restaurants)
            {
                if (restaurant.Id == x.Id)
                {
                    restaurant.Name = x.Name;
                    restaurant.Ratings = x.Ratings;
                    restaurant.LogoUrl = x.LogoUrl;
                    restaurant.ReviewCount = x.ReviewCount;
                    restaurant.State = x.State;
                    restaurant.City = x.City;
                    restaurant.CuisineTags = x.CuisineTags;
                    restaurant.CuisineTagsRaw = x.CuisineTagsRaw;
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult ViewRestaurant(int id = -1)
        {
            if (id == -1) return RedirectToAction("Index");
            Restaurant restaurant = db.Restaurants.Where(x => x.Id == id).FirstOrDefault();
            return View(restaurant);
        }

        public ActionResult AddReview(int id = -1)
        {
            if (id == -1) return RedirectToAction("Index");
            Rating newReview = new Rating() { RestaurantId = id };
            newReview.RestaurantName = db.Restaurants.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();
            return View(newReview);
        }

        [HttpPost]
        public ActionResult AddReview(Rating newReview)
        {
            if (db.Restaurants.Any(x => x.Id == newReview.RestaurantId))
            {
                newReview.Id = db.Restaurants.Where(x => x.Id == newReview.RestaurantId).FirstOrDefault().Ratings.Select(x => x.Id).LastOrDefault() + 1;
                db.Restaurants.Where(x => x.Id == newReview.RestaurantId).FirstOrDefault().Ratings.Add(newReview);
                db.Restaurants.Where(x => x.Id == newReview.RestaurantId).FirstOrDefault().UpdateAverage();
                return RedirectToAction("ViewRestaurant", new { Id = newReview.RestaurantId });
            }
            else
                return RedirectToAction("Index");
        }

        public ActionResult DeleteReview(int restaurantId = -1, int reviewId = -1)
        {
            if (restaurantId != -1 && reviewId != -1)
            {
                Rating deleteReview = db.Restaurants.Where(x => x.Id == restaurantId).FirstOrDefault().Ratings.Where(x => x.Id == reviewId).FirstOrDefault();
                db.Restaurants.Where(x => x.Id == restaurantId).FirstOrDefault().Ratings.Remove(deleteReview);
                db.Restaurants.Where(x => x.Id == restaurantId).FirstOrDefault().UpdateAverage();
            }
            return RedirectToAction("ViewRestaurant", new { Id = restaurantId });
        }
    }
}