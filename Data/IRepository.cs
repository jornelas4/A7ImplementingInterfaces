using System.Collections.Generic;
using A7ImplementingInterfaces.MovieObjects;

namespace A7ImplementingInterfaces.Data
{
    public interface IRepository
    {
        void WriteToFile(Movie movie);
        List<Movie> ReadFromJsonFile();
        int GetNextId();
    }
}