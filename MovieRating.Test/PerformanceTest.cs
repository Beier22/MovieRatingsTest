using MovieRating.Core;
using MovieRating.Core.Entity;
using MovieRating.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace MovieRating.Test
{
    public class PerformanceTest
    {

        IMovieRatingService serv = new MovieRatingService("../../../../ratings.json");
        Stopwatch stopwatch;
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
        [Theory]
        [InlineData(10)]
        public void Test1(int reviewer)
        {
            checkPerformance();
            List<Review> reviews = serv.GetReviewsFromReviewer(reviewer);
            int actual = reviews.Count;
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }

        //2. On input N, what is the average rate that reviewer N had given?
        [Theory]
        [InlineData(2)]
        public void Test2(int reviewer)
        {
            checkPerformance();
            double actual = serv.GetAverageReviewerRating(reviewer);
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }

        //3. On input N and G, how many times has reviewer N given a movie grade G?
        [Theory]
        [InlineData(5, 3)]
        public void Test3(int reviewer, int grade)
        {
            checkPerformance();
            List<Review> reviews = serv.GetReviewsFromReviewerWithRating(reviewer, grade);
            int actual = reviews.Count;
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }


        //4. On input N, how many have reviewed movie N?
        [Theory]
        [InlineData(12)]
        public void Test4(int movie)
        {
            checkPerformance();
            List<Review> reviews = serv.GetMovieReviews(movie);
            int actual = reviews.Count;
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }


        //5. On input N, what is the average rate the movie N had received?
        [Theory]
        [InlineData(15)]
        [InlineData(12)]
        [InlineData(18)]
        [InlineData(14)]
        [InlineData(16)]
        public void Test5(int movie)
        {
            checkPerformance();
            double actual = serv.GetAverageMovieRating(movie);
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }


        //6. On input N and G, how many times had movie N received grade G?
        [Theory]
        [InlineData(2, 2)]
        public void Test6(int movie, int grade)
        {
            checkPerformance();
            int actual = serv.GetMovieRatingNumber(movie, grade);
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
        [Theory]
        [InlineData(3, new int[] { 14, 16, 12 })]
        public void Test9(int input, int[] expected)
        {
            checkPerformance();
            var list  = serv.GetTopMovies(input).OrderBy(x => x);
            var list2 = new List<int>(expected).OrderBy(x => x);
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }
        */

        //10. On input N, what are the movies that reviewer N has reviewed? The list should
        //be sorted decreasing by rate first, and date secondly.
        [Theory]
        [InlineData(6, new int[] { 15, 19, 7 })]
        public void Test10(int input, int[] expected)
        {
            checkPerformance();
            var list1 = new List<int>(expected);
            var list2 = serv.GetMoviesReviewedByReviewer(input);
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }


        //11. On input N, what are the reviewers that have reviewed movie N? The list
        //should be sorted decreasing by rate first, and date secondly.
        [Theory]
        [InlineData(8, new int[]{9,5,10})]
        public void Test11(int input, int[] expected)
        {
            checkPerformance();
            var list1 = new List<int>(expected);
            var list2 = serv.GetReviewersOfMovie(input);
            stopwatch.Stop();
            Assert.True(4 >= stopwatch.Elapsed.TotalSeconds);
        }
        
    }
}
