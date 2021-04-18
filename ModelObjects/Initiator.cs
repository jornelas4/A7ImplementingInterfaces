using System;
using System.Collections.Generic;

namespace A7ImplementingInterfaces.ModelObjects
{
    public static class Initiator
    {
        
                public static Movie GetMovie(int id)
        {
            Console.WriteLine("What title do you want to choose from?");
            string title = Console.ReadLine();

            string userInput;
            List<string> genres = new List<string>();
            do
            {
                Console.WriteLine("Please add movie genre: \n Enter 3 for none:");
                userInput = Console.ReadLine();

                if (userInput != "3") 
                {
                    genres.Add(userInput);
                }
            } while (userInput != "3");

            return new Movie(title, id, genres);
        }
    }
}