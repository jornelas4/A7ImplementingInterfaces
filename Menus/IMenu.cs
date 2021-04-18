using A7ImplementingInterfaces.Data;
using A7ImplementingInterfaces.Menus;
using A7ImplementingInterfaces.ModelObjects;
namespace A7ImplementingInterfaces.Menus
{
    public interface IMenu
    {
        bool ValidMenu { get; set; }

        void DisplayMenu();
        void logics(char input);
        void Add(char input);
        void PrintList(char input);

    }
}