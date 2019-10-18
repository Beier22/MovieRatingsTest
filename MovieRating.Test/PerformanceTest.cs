using MovieRating.Core;
using MovieRating.Core.Entity;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace MovieRating.Test
{
    public class PerformanceTest
    {
        private IMovieRatingService serv = new MovieRatingService("../../../../ratings.json");
        private Stopwatch stopwatch;

        public void checkPerformance()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        [Fact]
        public void TestReader()
        {
            checkPerformance();
            serv.amountOfReviews();
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }

        //1. On input N, what are the number of reviews from reviewer N?
        [Fact]
        public void Test1()
        {
            checkPerformance();
            List<Review> reviews = serv.GetReviewsFromReviewer(10);
            int actual = reviews.Count;
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }

        //2. On input N, what is the average rate that reviewer N had given?
        [Fact]
        public void Test2()
        {
            checkPerformance();
            double actual = serv.GetAverageReviewerRating(2);
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }

        //3. On input N and G, how many times has reviewer N given a movie grade G?
        [Fact]
        public void Test3()
        {
            checkPerformance();
            List<Review> reviews = serv.GetReviewsFromReviewerWithRating(5, 3);
            int actual = reviews.Count;
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }

        //4. On input N, how many have reviewed movie N?
        [Fact]
        public void Test4()
        {
            checkPerformance();
            List<Review> reviews = serv.GetMovieReviews(12);
            int actual = reviews.Count;
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }

        //5. On input N, what is the average rate the movie N had received?
        [Fact]
        public void Test5()
        {
            checkPerformance();
            double actual = serv.GetAverageMovieRating(15);
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }

        //6. On input N and G, how many times had movie N received grade G?
        [Fact]
        public void Test6()
        {
            checkPerformance();
            int actual = serv.GetMovieRatingNumber(2, 2);
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }

        //7. What is the id(s) of the movie(s) with the highest number of top rates (5)?
        [Fact]
        public void Test7()
        {
            checkPerformance();
            List<int> actual = serv.GetMostTopRatedMovies();
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }

        //8. What reviewer(s) had done most reviews?
        [Fact]
        public void Test8()
        {
            checkPerformance();
            List<int> actual = serv.GetMostPublishedReviewer();
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }

        /*
        //9. On input N, what is top N of movies? The score of a movie is its average rate.
        [Fact]
        public void Test9()
        {
            checkPerformance();
            var list  = serv.GetTopMovies(1).OrderBy(x => x);
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }
        */

        //10. On input N, what are the movies that reviewer N has reviewed? The list should
        //be sorted decreasing by rate first, and date secondly.
        [Fact]
        public void Test10()
        {
            checkPerformance();
            var list = serv.GetMoviesReviewedByReviewer(6);
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }

        //11. On input N, what are the reviewers that have reviewed movie N? The list
        //should be sorted decreasing by rate first, and date secondly.
        [Fact]
        public void Test11()
        {
            checkPerformance();
            var list = serv.GetReviewersOfMovie(8);
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }
    }
}