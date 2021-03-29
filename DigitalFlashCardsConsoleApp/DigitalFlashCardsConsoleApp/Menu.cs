using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalFlashCardsConsoleApp
{
    class Menu
    {
        private static int selection = 0;
        private static int[] validSelections = { 1, 2, 3 };
        public static void Run()
        {
            Console.WriteLine("Welcome to the MEMORIZER, your personal Digital Flash Cards App!\n\n");
            do
            {
                displayMainMenuOptions();
                selection = getValidSelection();
                switch (selection)
                {
                    case 1:
                        break;
                    case 2:
                        // TODO: Create a method to log in
                        // Assume the user was able to log in successfully
                        User user = new User();
                        user.FirstName = "Jae";
                        user.LastName = "Yi";
                        user.EmailAddress = "jjj@jjj.com";
                        Console.WriteLine("Please enter the following information to add a flash card:");
                        Console.Write("Enter category >> ");
                        string cat = Console.ReadLine();
                        Console.Write("Enter question >> ");
                        string q = Console.ReadLine();
                        Console.Write("Enter answer >> ");
                        string a = Console.ReadLine();
                        user.AddFlashCard(cat, q, a);

                        break;
                    default:
                        return;
                }

                foreach (var item in Database.Users)
                {
                    Console.WriteLine($"{item.FullName}");
                }

                foreach (var item in Database.FlashCards)
                {
                    Console.WriteLine($"{item.Category.Name} {item.Category.Desc} {item.Question} {item.Answer} {item.UserID}");
                }

                foreach (var item in Database.Categories)
                {
                    Console.WriteLine($"{item.UserID} {item.Name} {item.Desc}");
                }

            } while (true);

        }

        private static void displayMainMenuOptions()
        {
            Console.WriteLine("Please choose one of the options below:\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  [1] Register for an account");
            Console.WriteLine("  [2] Log in to your account");
            Console.WriteLine("  [3] Exit");
            Console.ResetColor();
            Console.WriteLine();
        }

        private static int getValidSelection()
        {
            Console.Write("Enter your selection >> ");
            string userInput = Console.ReadLine();
            if (isValid(userInput)) return selection;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid selection.  Please try again.\n");
                Console.ResetColor();
                return getValidSelection();
            }
        }

        private static bool isValid(string userInput)
        {
            return int.TryParse(userInput, out selection) && 
                validSelections.Any(p => p == selection);
        }
    }
}
