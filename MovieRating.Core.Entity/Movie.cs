using System.Collections;

namespace MovieRating.Core.Entity
{
    public class Movie
    {
        public int MovieId { get; set; }
        public IDictionary Rating { get; set; }

    }
}