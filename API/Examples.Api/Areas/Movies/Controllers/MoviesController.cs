using System.Collections.Generic;
using System.Linq;
using Examples.Api.Areas.Movies.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Api.Areas.Movies.Controllers
{
    [Route("api/movies")]
    public class MoviesController : Controller
    {
        private readonly List<MovieItem> Items;

        public MoviesController()
        {
            Items = new List<MovieItem>();
            Items.Add(CreateMovie("tt4574334", "Stranger Things", 9.0));
            Items.Add(CreateMovie("tt0475784", "Westworld", 8.9));
            Items.Add(CreateMovie("tt1856010", "House of Cards", 8.9));
            Items.Add(CreateMovie("tt2395427", "Avengers: Age of Ultron", 7.4));
            Items.Add(CreateMovie("tt0371746", "Iron Man", 7.9));
            Items.Add(CreateMovie("tt0458339", "Captain America: The First Avenger", 6.9));
            Items.Add(CreateMovie("tt0770703", "What's Your Number?", 6.1));
            Items.Add(CreateMovie("tt0489237", "The Nanny Diaries", 6.2));
            Items.Add(CreateMovie("tt0467200", "The Other Boleyn Girl", 6.7));
            Items.Add(CreateMovie("tt0127536", "Elizabeth", 7.5));
            Items.Add(CreateMovie("tt0138097", "Shakespeare in Love", 7.2));
            Items.Add(CreateMovie("tt0095953", "Rain Man", 8.0));
            Items.Add(CreateMovie("tt1504320", "The King's Speech", 8.0));
            Items.Add(CreateMovie("tt2084970", "The Imitation Game", 8.0));
            Items.Add(CreateMovie("tt2980516", "The Theory of Everything", 7.7));
            Items.Add(CreateMovie("tt0810819", "The Danish Girl", 7.1));
        }
        
        public ActionResult Get(string startsWith, int offset = 0, int limit = 20)
        {
            var all = Items
                .Where(_ => string.IsNullOrEmpty(startsWith) || _.Title.ToLower().StartsWith(startsWith.ToLower()))
                .Skip(offset).Take(limit).ToList();
            var model = new MoviesList();
            model.TotalCount = Items.Count;
            model.Items = all;
            return Json(all);
        }

        private MovieItem CreateMovie(string imdbId, string title, double rating)
        {
            var item = new MovieItem
            {
                ImdbId = imdbId,
                Title = title
            };
            return item;
        }
    }
}