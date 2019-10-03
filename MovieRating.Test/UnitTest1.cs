using MovieRating.Core;
using MovieRating.Core.Entity;
using MovieRating.Infrastructure;
using System;
using System.Collections.Generic;
using Xunit;

namespace MovieRating.Test
{
    public class UnitTest1
    {
        IRatingRepo repo = new RatingRepo("../../../../samples.json");
        IMovieRatingService serv = new MovieRatingService("../../../../samples.json");

        [Fact]
        public void TestReader()
        {
            int size = repo.AllReviews.Count;
            Assert.Equal(50, size);
        }

        //1. On input N, what are the number of reviews from reviewer N?
        [Theory]
        [InlineData(10, 7)]
        public void Test1(int reviewer, int expected)
        {
            List<Review> reviews = serv.GetReviewsFromReviewer(reviewer);
            int actual = reviews.Count;
            Assert.Equal(expected, actual);
        }

        //2. On input N, what is the average rate that reviewer N had given?
        [Theory]
        [InlineData(2, 2.43)]
        public void Test2(int reviewer, double expected)
        {
            double actual = serv.GetAverageReviewerRating(reviewer);
            Assert.Equal(expected, actual);
        }

        //3. On input N and G, how many times has reviewer N given a movie grade G?
        [Theory]
        [InlineData(5, 3, 2)]
        public void Test3(int reviewer, int grade, int expected)
        {
            List<Review> reviews = serv.GetReviewsFromReviewerWithRating(reviewer, grade);
            int actual = reviews.Count;
            Assert.Equal(expected, actual);
        }


        //4. On input N, how many have reviewed movie N?
        [Theory]
        [InlineData(12, 2)]
        public void Test4(int movie, int expected)
        {
            List<Review> reviews = serv.GetMovieReviews(movie);
            int actual = reviews.Count;
            Assert.Equal(expected, actual);
        }


        //5. On input N, what is the average rate the movie N had received?
        [Theory]
        [InlineData(15, 2.2)]
        public void Test5(int movie, double expected)
        {
            double actual = serv.GetAverageMovieRating(movie);
            Assert.Equal(expected, actual);
        }


        //6. On input N and G, how many times had movie N received grade G?
        [Theory]
        [InlineData(2, 2, 2)]
        public void Test6(int movie, int grade, int expected)
        {
            int actual = serv.GetMovieRatingNumber(movie, grade);
            Assert.Equal(expected, actual);
        }


        //7. What is the id(s) of the movie(s) with the highest number of top rates (5)?
        [Fact]
        public void Test7()
        {
            List<int> expected = new List<int> { 4, 14, 18 };
            List<int> actual = serv.GetMostTopRatedMovies();
            Assert.Equal(expected, actual);
        }


        //8. What reviewer(s) had done most reviews?
        [Fact]
        public void Test8()
        {
            List<int> expected = new List<int> { 2, 8, 9, 10 };
            List<int> actual = serv.GetMostPublishedReviewer();
            Assert.Equal(expected, actual);

        }


        //9. On input N, what is top N of movies? The score of a movie is its average rate.
        [Theory]
        [InlineData(10, 7)]
        public void Test9(int input, int expected)
        {
        }


        //10. On input N, what are the movies that reviewer N has reviewed? The list should
        //be sorted decreasing by rate first, and date secondly.
        [Theory]
        [InlineData(10, 7)]
        public void Test10(int input, int expected)
        {
        }


        //11. On input N, what are the reviewers that have reviewed movie N? The list
        //should be sorted decreasing by rate first, and date secondly.
        [Theory]
        [InlineData(10, 7)]
        public void Test11(int input, int expected)
        {
        }

    }
}
