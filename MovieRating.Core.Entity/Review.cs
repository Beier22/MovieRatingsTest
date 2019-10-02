using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Core.Entity
{
    public class Review
    {
        public int ReviewerId { get; set; }
        public int MovieId { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
    }
}
