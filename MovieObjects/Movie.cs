using System.Collections.Generic;
using Newtonsoft.Json;


namespace A7ImplementingInterfaces.MovieObjects
{
  [JsonObject(MemberSerialization.OptIn)]
    public class Movie

    {
        
        [JsonProperty]
        public int MovieID { get; set; }
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public List<string> Genres { get; set; }

        public Movie(int id, string title, List<string> genres)
        {
            MovieID = id;
            Title = title;
            Genres = genres;
        }

        public override string ToString()
        {
            string genres = "";
            foreach (string g in Genres)
            {
                genres += g + " | ";
            }
            return $"{MovieID, -5} {Title, -15} {genres, -30}";
        }
    }
}