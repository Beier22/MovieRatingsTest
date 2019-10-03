﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieRating.Core.Entity;
using MovieRating.Infrastructure;

namespace MovieRating.Core
{
    public class MovieRatingService : IMovieRatingService
    {
        IRatingRepo repo;
        
        public MovieRatingService(string path)
        {
            repo = new RatingRepo(path);
        }

        public double GetAverageMovieRating(int movie)
        {
            List<Review> reviews = repo.AllReviews.Where(r => r.Movie == movie).ToList();
            int i = 0;

            foreach (var review in reviews) {
                i += review.Grade;
            }

            double result = i / Convert.ToDouble(reviews.Count());
            return Math.Round(result, 2);
        }

        public double GetAverageReviewerRating(int reviewer)
        {
            List<Review> reviews = repo.AllReviews.Where(r => r.Reviewer == reviewer).ToList();
            int i = 0;

            foreach (var review in reviews)
            {
                i += review.Grade;
            }
            double result = i / Convert.ToDouble(reviews.Count());
            return Math.Round(result, 2);
        }

        public List<int> GetMostPublishedReviewer()
        {
            var reviews = repo.AllReviews.GroupBy(x => x.Reviewer).OrderByDescending(g => g.Count()).ToList();
            Review r = (Review)reviews[0];
            List<int> t = new List<int>();
            t.Add(r.Reviewer);
            return t;
        }

        public List<int> GetMostTopRatedMovies()
        {
            List<Review> reviews1 = repo.AllReviews.Where(r => r.Grade == 5).ToList();
            int movie;
            throw new NotImplementedException();
        }

        public int GetMovieRatingNumber(int movie, int rating)
        {
            List<Review> reviews1 = repo.AllReviews.Where(r => r.Movie == movie).ToList();
            List<Review> reviews2 = reviews1.Where(r => r.Grade == rating).ToList();
            return reviews2.Count();
        }

        public List<Review> GetMovieReviews(int movie)
        {
            return repo.AllReviews.Where(r => r.Movie == movie).ToList();
        }

        public List<int> GetMoviesReviewedByReviewer(int reviewer)
        {
            List<Review> reviews = repo.AllReviews.Where(r => r.Reviewer == reviewer).ToList();
            List<int> movies = new List<int>();
            foreach (var r in reviews)
            {
                movies.Add(r.Movie);
            }
            return movies;
        }

        public List<int> GetReviewersOfMovie(int movie)
        {

            throw new NotImplementedException();
        }

        public List<Review> GetReviewsFromReviewer(int reviewer)
        {
            return repo.AllReviews.Where(r => r.Reviewer == reviewer).ToList();
        }

        public List<Review> GetReviewsFromReviewerWithRating(int reviewer, int rating)
        {
            List<Review> reviews1 = repo.AllReviews.Where(r => r.Reviewer == reviewer).ToList();
            return reviews1.Where(r => r.Grade == rating).ToList();
        }

        public List<int> GetTopMovies(int n)
        {
            throw new NotImplementedException();
        }
    }
}
