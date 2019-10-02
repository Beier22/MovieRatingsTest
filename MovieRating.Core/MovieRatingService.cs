using System;
using System.Collections.Generic;
using System.Text;
using MovieRating.Core.Entity;
using MovieRating.Infrastructure;

namespace MovieRating.Core
{
    public class MovieRatingService : IMovieRatingService
    {
        IRatingRepo repo = new RatingRepo();
        public double GetAverageMovieRating(int movie)
        {
            throw new NotImplementedException();
        }

        public double GetAverageReviewerRating(int reviewer)
        {
            throw new NotImplementedException();
        }

        public List<int> GetMostPublishedReviewer()
        {
            throw new NotImplementedException();
        }

        public List<int> GetMostTopRatedMovies()
        {
            throw new NotImplementedException();
        }

        public int GetMovieRatingNumber(int movie, int rating)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetMovieReviews(int movie)
        {
            throw new NotImplementedException();
        }

        public List<int> GetMoviesReviewedByReviewer(int reviwer)
        {
            throw new NotImplementedException();
        }

        public List<int> GetReviewerOfMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetReviewsFromReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetReviewsFromReviewerWithRating(int reviewer, int rating)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTopMovies(int n)
        {
            throw new NotImplementedException();
        }
    }
}
