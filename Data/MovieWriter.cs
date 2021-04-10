using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using A7ImplementingInterfaces.MovieObjects;
using Newtonsoft.Json;


namespace A7ImplementingInterfaces.Data
{
public class MovieWriter : IRepository
    {
       private string archive = Path.Combine(Environment.CurrentDirectory, "Archive", "movies.json");
        private List<Movie> ListOfMovies;
        
        public void WriteToFile(Movie movie)
        {
            jsonFileToList();
            ListOfMovies.Add(movie);

            using (var streamWriter = new StreamWriter(archive))
            {
                string json = JsonConvert.SerializeObject(ListOfMovies, Formatting.Indented);

                streamWriter.Write(json);
            }
        }

        public List<Movie> ReadFromJsonFile()
        {
            jsonFileToList();
            return ListOfMovies;
        }

        private void jsonFileToList()
        {
            string json;
            using (var streamReader = new StreamReader(archive))
            {
                json = streamReader.ReadToEnd();
            }

            ListOfMovies = JsonConvert.DeserializeObject<List<Movie>>(json);
        }

        public int GetNextId()
        {
            jsonFileToList();
            ListOfMovies.Sort((x,y) => x.MovieID.CompareTo(y.MovieID));
            return ListOfMovies.Last().MovieID + 1;
        }
    }
}