using A7ImplementingInterfaces.MovieObjects;

namespace A7ImplementingInterfaces.Menus
{
public interface IMenu
    {
        bool ValidMenu { get; set; }
        void DisplayMenu();
        void ProcessInput(char input);
        void Add();
        Movie GetMovie();
        void PrintList();

    }
}