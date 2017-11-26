using Examples.Api.Models;

namespace Examples.Api.Areas.Movies.Models
{
    public class MoviesList : ItemList<MovieItem>
    {
        
    }

    public class MovieItem
    {
        public string ImdbId { get; set; }
        public string Title { get; set; }
        public double ImdbRating { get; set; }
    }
}