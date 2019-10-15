using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieRating.Core.Entity;
using MovieRating.Infrastructure;

namespace MovieRating.Core
{
    public class MovieRatingService : IMovieRatingService
    {
        public IRatingRepo Repo { get; }
        
        public MovieRatingService(string path)
        {
            Repo = new RatingRepo(path);
        }

        public int amountOfReviews() {
            return Repo.AllReviews.Count();
        }

        public double GetAverageMovieRating(int movie)
        {
            List<Review> reviews = Repo.AllReviews.Where(r => r.Movie == movie).ToList();
            int i = 0;

            foreach (var review in reviews) {
                i += review.Grade;
            }

            double result = i / Convert.ToDouble(reviews.Count());
            return Math.Round(result, 2);
        }

        public double GetAverageReviewerRating(int reviewer)
        {
            List<Review> reviews = Repo.AllReviews.Where(r => r.Reviewer == reviewer).ToList();
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
            List<int> l = new List<int>();
            foreach (var review in Repo.AllReviews) {
                if (l.Count == 0)
                {
                    l.Add(review.Reviewer);
                }
                else if (GetReviewsFromReviewer(l[0]).Count < GetReviewsFromReviewer(review.Reviewer).Count)
                {
                    l.Clear();
                    l.Add(review.Reviewer);
                }
                else if (GetReviewsFromReviewer(l[0]).Count == GetReviewsFromReviewer(review.Reviewer).Count && !l.Contains(review.Reviewer)) {
                    l.Add(review.Reviewer);
                }
            }
                l = l.OrderBy(x => x).ToList();
                return l;
        }

        public List<int> GetMostTopRatedMovies()
        {
            List<int> l = new List<int>();
            foreach (var review in Repo.AllReviews) {
                if (l.Count == 0)
                {
                    l.Add(review.Movie);
                }
                else if (GetMovieRatingNumber(l[0], 5) < GetMovieRatingNumber(review.Movie, 5))
                {
                    l.Clear();
                    l.Add(review.Movie);
                }
                else if (GetMovieRatingNumber(l[0], 5) == GetMovieRatingNumber(review.Movie, 5)&&!l.Contains(review.Movie)){
                    l.Add(review.Movie);
                }
            }
            l = l.OrderBy(x => x).ToList();
            return l;
           
        }

        public int GetMovieRatingNumber(int movie, int rating)
        {
            List<Review> reviews1 = Repo.AllReviews.Where(r => r.Movie == movie).ToList();
            List<Review> reviews2 = reviews1.Where(r => r.Grade == rating).ToList();
            return reviews2.Count();
        }

        public List<Review> GetMovieReviews(int movie)
        {
            return Repo.AllReviews.Where(r => r.Movie == movie).ToList();
        }

        public List<int> GetMoviesReviewedByReviewer(int reviewer)
        {
            List<Review> reviews = Repo.AllReviews.Where(r => r.Reviewer == reviewer).ToList();
            reviews = reviews.OrderByDescending(x => x.Grade).ThenByDescending(y => y.Date).ToList();
            List<int> movies = new List<int>();
            foreach (var r in reviews)
            {
                movies.Add(r.Movie);
            }
            return movies;
        }

        public List<int> GetReviewersOfMovie(int movie)
        {
            List<Review> reviews = Repo.AllReviews.Where(r => r.Movie == movie).ToList();
            reviews = reviews.OrderByDescending(x => x.Grade).ThenByDescending(y => y.Date).ToList();
            List<int> reviewers = new List<int>();
            foreach (var r in reviews)
            {
                reviewers.Add(r.Reviewer);
            }
            return reviewers;

        }

        public List<Review> GetReviewsFromReviewer(int reviewer)
        {
            return Repo.AllReviews.Where(r => r.Reviewer == reviewer).ToList();
        }

        public List<Review> GetReviewsFromReviewerWithRating(int reviewer, int rating)
        {
            List<Review> reviews1 = Repo.AllReviews.Where(r => r.Reviewer == reviewer).ToList();
            return reviews1.Where(r => r.Grade == rating).ToList();
        }

        public List<int> GetTopMovies(int n)
        {
            Dictionary<int, double> dict = new Dictionary<int, double>();
            foreach(var review in Repo.AllReviews)
            {
                double rating = GetAverageMovieRating(review.Movie);
                try
                {
                    dict.Add(review.Movie, rating);
                }
                catch (ArgumentException) { }
            }
            dict = dict.OrderByDescending(x => x.Value).Take(n).ToDictionary(d => d.Key, m => m.Value);
            return new List<int>(dict.Keys);
            
        }
        }
    }

