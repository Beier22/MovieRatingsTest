using MovieRating.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MovieRating.Infrastructure
{
    public class JSONReader
    {
        public static List<Review> LoadJson()
        {
            using (StreamReader r = new StreamReader("../../../../ratings.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Review>>(json);
            }
            
        }

        
    }
}
