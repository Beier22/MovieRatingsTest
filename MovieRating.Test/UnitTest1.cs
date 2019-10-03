using MovieRating.Core;
using MovieRating.Infrastructure;
using System;
using Xunit;

namespace MovieRating.Test
{
    public class UnitTest1
    {
        IRatingRepo repo = new RatingRepo("../../../../ratings.json");
        IMovieRatingService serv = new MovieRatingService("../../../../ratings.json");

        [Fact]
        public void TestReader()
        {
            int size = repo.AllReviews.Count;
            Assert.Equal(5009439, size);
        }
        //1. On input N, what are the number of reviews from reviewer N?
        [Theory]
        [InlineData(1)]
        public void Test1(int reviewer)
        {
            

        }

        //2. On input N, what is the average rate that reviewer N had given?



        //3. On input N and G, how many times has reviewer N given a movie grade G?



        //4. On input N, how many have reviewed movie N?



        //5. On input N, what is the average rate the movie N had received?



        //6. On input N and G, how many times had movie N received grade G?



        //7. What is the id(s) of the movie(s) with the highest number of top rates (5)?



        //8. What reviewer(s) had done most reviews?



        //9. On input N, what is top N of movies? The score of a movie is its average rate.



        //10. On input N, what are the movies that reviewer N has reviewed? The list should
        //be sorted decreasing by rate first, and date secondly.



        //11. On input N, what are the reviewers that have reviewed movie N? The list
        //should be sorted decreasing by rate first, and date secondly.


    }
}
