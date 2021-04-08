using System;
using A7ImplementingInterfaces.Data;
using A7ImplementingInterfaces.Menus;
using Microsoft.Extensions.DependencyInjection;


namespace A7ImplementingInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRepository, MovieWriter>()
                .AddSingleton<IMenu, Menu>()
                .BuildServiceProvider();

            var menu = serviceProvider.GetService<IMenu>();

            while (menu.ValidMenu)
            {
                menu.DisplayMenu();
            }
            
            Console.WriteLine("Thank you for using the  movie library.");
        }
    }
}
