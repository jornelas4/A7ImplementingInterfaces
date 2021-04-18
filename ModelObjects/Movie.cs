using System.Collections.Generic;
using Newtonsoft.Json;

namespace A7ImplementingInterfaces.ModelObjects
{
    public class Movie : EntertainmentType
    {
        public int MovieID { get; set; }

        public Movie(string title, int id, List<string> genres)
        {
            MovieID = id;
            Title = title;
            Genres = genres;
        }

        public override string ToString()
        {
            string genres = "";
            foreach (string type in Genres)
            {
                genres += type + " | ";
            }
            return $"{MovieID, -10}  {Title, -30} {genres, -40}";
        }
    }
}