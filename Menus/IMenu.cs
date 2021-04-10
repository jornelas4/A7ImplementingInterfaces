using A7ImplementingInterfaces.MovieObjects;

namespace A7ImplementingInterfaces.Menus
{
public interface IMenu
    {
        bool logicalMenu { get; set; }
        void exhibitMenu();
        void ProcedureInput(char input);
        void Add();
        Movie GetMovie();
        void PrintList();

    }
}