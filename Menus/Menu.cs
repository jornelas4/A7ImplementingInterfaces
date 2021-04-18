using System;
using System.Collections.Generic;
using A7ImplementingInterfaces.ModelObjects;
using A7ImplementingInterfaces.Data;

namespace A7ImplementingInterfaces.Menus
{
    public class Menu : IMenu
    {
        public bool ValidMenu { get; set; }
        private readonly char _exitKey = 'Q';
        private readonly List<char> _menuChoices = new List<char> {'1','2','3'};
        private FileWriter<Movie> _movieWriter;
        
        

        public Menu(FileWriter<Movie> movieWriter)
        {
            ValidMenu = true;
            _movieWriter = movieWriter;
        }

        public void DisplayMenu()
        {
            char userInput;
            do
            {
                Console.WriteLine("Would you like to:\n1. Add a media object to the file\n2. Display a list of media\n3. Search\nQ. Terminate");
                userInput = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (Char.ToUpper(userInput) != _exitKey && !_menuChoices.Contains(userInput));
            
            logics(userInput);
        }

        public void logics(char input)
        {
            switch (input)
            {
                case '1': 
                    Add(GetMediaType());
                    break;
                case '2':
                    PrintList(GetMediaType());
                    break;
                case '3':
                    SearchEntertainment.SearchList(CombineLists());
                    break;
                case 'q':
                case 'Q':
                    Console.WriteLine("Closing transaction...");
                    ValidMenu = false;
                    break;
            }
        }

        public void Add(char input)
        {
            switch (input)
            {
                case '1':
                    _movieWriter.WriteToFile(Initiator.GetMovie(_movieWriter.GetNextId()));
                    Console.WriteLine("Your movie has been added");
                    break;
            }
        }

        public void PrintList(char input)
        {
            switch (input)
            {
                case '1':
                    List<Movie> movies = _movieWriter.ReadFromFile();

                    Console.WriteLine($"{"ID", -5} {"Title", -30} {"Genres", -50}");

                    foreach (var m in movies)
                    {
                        Console.WriteLine(m.ToString());
                    }

                    break;
            }

        }

        public char GetMediaType()
        {
            List<char> validInputs = new List<char> {'1'};
            
            char userInput;
            do
            {
                Console.WriteLine("1. Movie");
                userInput = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (!validInputs.Contains(userInput))
                {
                    Console.WriteLine(" Not a valid option. Try again.");
                }
            } while (!validInputs.Contains(userInput));

            return userInput;
        }

        private List<EntertainmentType> CombineLists()
        {
            List<EntertainmentType> allMedia = new List<EntertainmentType>();

            foreach (Movie m in _movieWriter.ReadFromFile())
            {
                allMedia.Add(m);
            }

            return allMedia;
        }
    }
}