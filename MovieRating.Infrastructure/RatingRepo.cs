using MovieRating.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Infrastructure
{
    public class RatingRepo: IRatingRepo
    {
        public List<Review> AllReviews { get; }

        public RatingRepo()
        {
            AllReviews = JSONReader.LoadJson();
        }


        
    }
}
