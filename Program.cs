using System;
using A7ImplementingInterfaces.Data;
using A7ImplementingInterfaces.ModelObjects;
using A7ImplementingInterfaces.Menus;
using Microsoft.Extensions.DependencyInjection;

namespace MediaLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<FileWriter<Movie>, WriteMovie>()
                .AddSingleton<IMenu, Menu>()
                .BuildServiceProvider();

            var menu = serviceProvider.GetService<IMenu>();

            while (menu.ValidMenu)
            {
                menu.DisplayMenu();
            }
            
            Console.WriteLine("Thanks for using the Redbox library.");
        }
    }
}