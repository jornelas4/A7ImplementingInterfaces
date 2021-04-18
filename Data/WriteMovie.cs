using System;
using System.Collections.Generic;
using System.IO;
using A7ImplementingInterfaces.ModelObjects;
using Newtonsoft.Json;
using System.Linq;

namespace A7ImplementingInterfaces.Data
{
    public class WriteMovie : FileWriter<Movie>
    {
        private string File = Path.Combine(Environment.CurrentDirectory, "Archive", "Movies.json");
        private List<Movie> ListOfMovies;
        
        public void WriteToFile(Movie movie)
        {
            FileToList();
            ListOfMovies.Add(movie);

            using (StreamWriter sw = new StreamWriter(File))
            {
                string json = JsonConvert.SerializeObject(ListOfMovies,Formatting.Indented,new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });

                sw.Write(json);
            }
        }

        public List<Movie> ReadFromFile()
        {
            FileToList();
            return ListOfMovies;
        }

        private void  FileToList()
        {
            string json;
            using (StreamReader sr = new StreamReader(File))
            {
                json = sr.ReadToEnd();
            }

            ListOfMovies = JsonConvert.DeserializeObject<List<Movie>>(
                json,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                });
        
        }

        public int GetNextId()
        {
            FileToList();
            ListOfMovies.Sort((a,b) => a.MovieID.CompareTo(b.MovieID));
            return ListOfMovies.Last().MovieID + 1;
        }
    }
}