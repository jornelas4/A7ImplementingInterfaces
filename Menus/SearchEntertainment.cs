using System;
using System.Collections.Generic;
using System.Linq;
using A7ImplementingInterfaces.ModelObjects;


namespace A7ImplementingInterfaces.Menus
{


    public static class SearchEntertainment
    {
        private static List<EntertainmentType> _EntertainmentList;
        
        public static void SearchList(List<EntertainmentType> entertainmentList)
        {
            _EntertainmentList = entertainmentList;
            
            logics(GetUserInput());
        }

        private static char GetUserInput()
        {
            List<char> validInput = new List<char> {'1', '2'};
            char userInput;

            do
            {
                Console.WriteLine("What would you like to search by?\n1. Title\n2. Genre\n");
                userInput = Console.ReadKey().KeyChar;

                if (!validInput.Contains(userInput))
                {
                    Console.WriteLine("Please try again that was not a valid option.");
                }
            } while (!validInput.Contains(userInput));

            return userInput;
        }

        private static void logics(char input)
        {
            switch (input)
            {
                case '1':
                    Console.WriteLine("Enter title: ");
                    string title = Console.ReadLine();
                    SearchTitle(title);
                    break;
                case '2':
                    Console.WriteLine("Enter genre: ");
                    string genre = Console.ReadLine();
                    SearchByGenre(genre);
                    break;
            }
        }

        private static void SearchTitle(string title)
        {
            var listOfMatches = _EntertainmentList.Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
            DisplayResults(listOfMatches.ToList());
        }

        private static void SearchByGenre(string genre)
        {
            var listOfMatches = _EntertainmentList.Where(m => m.Genres.Contains(genre, StringComparer.OrdinalIgnoreCase));
            DisplayResults(listOfMatches.ToList());
        }

        private static void DisplayResults(List<EntertainmentType> matches)
        {
            Console.WriteLine($"Matches Found: {matches.Count}");
            
            foreach (EntertainmentType m in matches)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
}