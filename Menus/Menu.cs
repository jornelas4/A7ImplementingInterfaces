using System;
using System.Collections.Generic;
using A7ImplementingInterfaces.Data;
using A7ImplementingInterfaces.MovieObjects;

namespace A7ImplementingInterfaces.Menus
{
    public class Menu : IMenu


    {
        public bool ValidMenu { get; set; }
        private readonly char _exitKey = 'Q';
        private readonly List<char> _menuChoices = new List<char> {'1', '2'};
        private IRepository _movieWriter;

        public Menu(IRepository writer)
        {
            ValidMenu = true;
            _movieWriter = writer;
        }

        public void DisplayMenu()
        {
            char userInput;
            do
            {
                Console.WriteLine("What would you like to do:\n1. Add a movie\n2. Display all movies\n" +
                "Q. Exit");
                userInput = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (Char.ToUpper(userInput) != _exitKey && !_menuChoices.Contains(userInput));
            
            ProcessInput(userInput);
        }

        public void ProcessInput(char input)
        {
            switch (input)
            {
                case '1': 
                    Add();
                    break;
                case '2':
                    PrintList();
                    break;
                case 'q':
                case 'Q':
                    Console.WriteLine("Exiting...");
                    ValidMenu = false;
                    break;
            }
        }

        public void Add()
        {
            _movieWriter.WriteToFile(GetMovie());
            
            Console.WriteLine("The movie has been added");
        }

        public Movie GetMovie()
        {
            Console.WriteLine("Enter the movie title?");
            string title = Console.ReadLine();

            string userInput;
            List<string> genres = new List<string>();

            do
            {
                Console.WriteLine("Please enter genre (S to stop):");
                userInput = Console.ReadLine().ToUpper();

                if (userInput != "S") 
                {
                    genres.Add(userInput);
                }
            } while (userInput != "S");

            return new Movie(_movieWriter.GetNextId(), title, genres);
        }

        public void PrintList()
        {
            List<Movie> movies = _movieWriter.ReadFromFile();

            Console.WriteLine($"{"ID", -5} {"Title", -15} {"Genres", -30}");

            foreach (var m in movies)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
}