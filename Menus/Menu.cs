using System;
using System.Collections.Generic;
using A7ImplementingInterfaces.Data;
using A7ImplementingInterfaces.MovieObjects;

namespace A7ImplementingInterfaces.Menus
{
    public class Menu : IMenu


    {
        public bool logicalMenu { get; set; }
        private readonly char _terminate = 'Q';
        private readonly List<char> _menuChoices = new List<char> {'1', '2'};
        private IRepository _movieWriter;

        public Menu(IRepository writer)
        {
            logicalMenu = true;
            _movieWriter = writer;
        }

        public void exhibitMenu()
        {
            char userInput;
            do
            {
                Console.WriteLine("What would you like to do:\n1. Add a movie\n2. Display all movies\n" +
                "Q. Exit");
                userInput = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (Char.ToUpper(userInput) != _terminate && !_menuChoices.Contains(userInput));
            
            ProcedureInput(userInput);
        }

        public void ProcedureInput(char input)
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
                    Console.WriteLine("This session has ended");
                    logicalMenu = false;
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
            List<Movie> movies = _movieWriter.ReadFromJsonFile();

            Console.WriteLine($"{"ID", -5} {"Title", -15} {"Genres", -30}");

            foreach (var m in movies)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
}