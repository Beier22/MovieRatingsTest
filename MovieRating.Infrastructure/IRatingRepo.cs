using MovieRating.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Infrastructure
{
    public interface IRatingRepo
    {
        List<Review> AllReviews { get; }

        
    }
}
