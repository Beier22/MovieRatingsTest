using MovieRating.Infrastructure;
using System;
using Xunit;

namespace MovieRating.Test
{
    public class UnitTest1
    {
        IRatingRepo repo = new RatingRepo();

        [Fact]
        public void TestReader()
        {
            int size = repo.AllReviews.Count;
            Assert.Equal(5009439, size);
        }
        [Theory]
        [InlineData(1)]
        public void Test1(int reviewer)
        {
            


        }
    }
}
