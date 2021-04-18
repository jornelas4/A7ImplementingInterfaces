using System.Collections.Generic;

namespace A7ImplementingInterfaces.ModelObjects
{
    public abstract class EntertainmentType
    {
        public string Title { get; set; }

        public List<string> Genres { get; set; }
    }
}