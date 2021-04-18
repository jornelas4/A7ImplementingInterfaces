using System.Collections.Generic;
using A7ImplementingInterfaces.ModelObjects;

namespace A7ImplementingInterfaces.Data
{
    public interface FileWriter<T> where T : EntertainmentType
    {
        void WriteToFile(T media);
        List<T> ReadFromFile();
        int GetNextId();
    }
}