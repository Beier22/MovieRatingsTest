using MovieRating.Core.Entity;
using MovieRating.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Core
{
    public interface IMovieRatingService
    {
        int amountOfReviews();
        IRatingRepo Repo { get; }
        //1. On input N, what are the number of reviews from reviewer N?
        List<Review> GetReviewsFromReviewer(int reviewer);
        //2. On input N, what is the average rate that reviewer N had given?
        double GetAverageReviewerRating(int reviewer);
        //3. On input N and G, how many times has reviewer N given a movie grade G?
        List<Review> GetReviewsFromReviewerWithRating(int reviewer, int rating);
        //4. On input N, how many have reviewed movie N?
        List<Review> GetMovieReviews(int movie);
        //5. On input N, what is the average rate the movie N had received?
        double GetAverageMovieRating(int movie);
        //6. On input N and G, how many times had movie N received grade G?
        int GetMovieRatingNumber(int movie, int rating);
        //7. What is the id(s) of the movie(s) with the highest number of top rates (5)?
        List<int> GetMostTopRatedMovies();
        //8. What reviewer(s) had done most reviews?
        List<int> GetMostPublishedReviewer();
        //9. On input N, what is top N of movies? The score of a movie is its average rate.
        List<int> GetTopMovies(int n);
        //10. On input N, what are the movies that reviewer N has reviewed? The list should
        //be sorted decreasing by rate first, and date secondly.
        List<int> GetMoviesReviewedByReviewer(int reviewer);
        //11. On input N, what are the reviewers that have reviewed movie N? The list
        //should be sorted decreasing by rate first, and date secondly.
        List<int> GetReviewersOfMovie(int movie);

    }
}