using MovieRating.Core.Entity;
using MovieRating.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRating.Core
{
    public class MovieRatingService : IMovieRatingService
    {
        public IRatingRepo Repo { get; }
        public List<Movie> movies { set; get; }

        public MovieRatingService(string path)
        {
            Repo = new RatingRepo(path);
        }

        public int amountOfReviews()
        {
            return Repo.AllReviews.Count();
        }

        public double GetAverageMovieRating(int movie)
        {
            List<Review> reviews = Repo.AllReviews.Where(r => r.Movie == movie).ToList();
            if (reviews.Count == 0)
            {
                return 0;
            }
            int i = 0;

            foreach (var review in reviews)
            {
                i += review.Grade;
            }

            double result = i / Convert.ToDouble(reviews.Count());
            return Math.Round(result, 2);
        }

        public double GetAverageReviewerRating(int reviewer)
        {
            List<Review> reviews = Repo.AllReviews.Where(r => r.Reviewer == reviewer).ToList();
            if (reviews.Count == 0)
            {
                return 0;
            }
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
            foreach (var review in Repo.AllReviews)
            {
                if (l.Count == 0)
                {
                    l.Add(review.Reviewer);
                }
                else if (GetReviewsFromReviewer(l[0]).Count < GetReviewsFromReviewer(review.Reviewer).Count)
                {
                    l.Clear();
                    l.Add(review.Reviewer);
                }
                else if (GetReviewsFromReviewer(l[0]).Count == GetReviewsFromReviewer(review.Reviewer).Count && !l.Contains(review.Reviewer))
                {
                    l.Add(review.Reviewer);
                }
            }
            l = l.OrderBy(x => x).ToList();
            return l;
        }

        public List<int> GetMostTopRatedMovies()
        {
            movies = GenerateMovies();
            foreach (Movie m in movies) {
                Dictionary<int, int> gradeNumber = new Dictionary<int, int>();
                gradeNumber.Add(5, GetMovieRatingNumber(m.MovieId, 5));
                m.Rating = gradeNumber;
            }
            movies = movies.OrderByDescending(m => m.Rating[5]).ToList();
            List<Movie> most5gradeMovies = movies.Where(m => (int)m.Rating[5] == (int)movies[0].Rating[5] ).ToList();
            List<int> returnIds = new List<int>();
            foreach (var movie in most5gradeMovies) {
                returnIds.Add(movie.MovieId);
            }
            return returnIds;
        }

        public int GetMovieRatingNumber(int movie, int rating)
        {
            List<Review> reviews = Repo.AllReviews.Where(r => r.Movie == movie).ToList();
            if (reviews.Count == 0)
            {
                return 0;
            }
            reviews = reviews.Where(r => r.Grade == rating).ToList();
            return reviews.Count();
        }

        public List<Review> GetMovieReviews(int movie)
        {
            return Repo.AllReviews.Where(r => r.Movie == movie).ToList();
        }

        public List<int> GetMoviesReviewedByReviewer(int reviewer)
        {
            List<Review> reviews = Repo.AllReviews.Where(r => r.Reviewer == reviewer).ToList();
            List<int> movies = new List<int>();
            if (reviews.Count == 0)
            {
                return movies;
            }
            reviews = reviews.OrderByDescending(x => x.Grade).ThenByDescending(y => y.Date).ToList();
            
            foreach (var r in reviews)
            {
                movies.Add(r.Movie);
            }
            return movies;
        }

        public List<int> GetReviewersOfMovie(int movie)
        {
            List<int> reviewers = new List<int>();
            List<Review> reviews = Repo.AllReviews.Where(r => r.Movie == movie).ToList();
            if (reviews.Count == 0)
            {
                return reviewers;
            }

            reviews = reviews.OrderByDescending(x => x.Grade).ThenByDescending(y => y.Date).ToList();
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
            List<Review> reviews = Repo.AllReviews.Where(r => r.Reviewer == reviewer).ToList();
            return reviews.Where(r => r.Grade == rating).ToList();
        }

        public List<int> GetTopMovies(int n)
        {
            Dictionary<int, double> dict = new Dictionary<int, double>();
            foreach (var review in Repo.AllReviews)
            {
                if (!dict.ContainsKey(review.Movie))
                {
                    double rating = GetAverageMovieRating(review.Movie);
                    dict.Add(review.Movie, rating);
                }
            }
            dict = dict.OrderByDescending(x => x.Value).Take(n).ToDictionary(d => d.Key, m => m.Value);
            return new List<int>(dict.Keys);
        }

        public List<Movie> GenerateMovies()
        {
            List <Movie> movies = new List<Movie>();
            foreach(var review in Repo.AllReviews)
            {
                if (movies.Where(p => p.MovieId == review.Movie).Count() == 0){
                    movies.Add(new Movie { MovieId = review.Movie, Rating = null });
                }
            }
            return movies.OrderBy(m => m.MovieId).ToList();
        }
    }
}