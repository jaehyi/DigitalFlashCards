using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace DigitalFlashCardsConsoleApp
{
    class User
    {
        private static int numberOfUsers = 1;
        private int _userID = numberOfUsers;
        public int UserID { get => _userID; }
            
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Last Name cannot be blank.");
                _lastName = value.Trim();
            }
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("First Name cannot be blank.");
                _firstName = value.Trim();
            }
        }

        public string FullName 
        {
            get
            {
                if (string.IsNullOrEmpty(_lastName) || string.IsNullOrEmpty(_firstName))
                    throw new ArgumentException("First name, last name, or both have not been set.");
                    
                return $"{_firstName} {_lastName}";
            }
        }

        private string _emailAddress;
        public string EmailAddress
        {
            get => _emailAddress;
            set 
            {
                MailAddress mail = new MailAddress(value);
                if (!mail.Host.Contains('.')) throw new ArgumentException("Invalid email entered.");
                _emailAddress = value;
            }
        }

        public User() => numberOfUsers++;

        public void AddFlashCard(string categoryName, string question, string answer)
        {
            FlashCard flashCard = new FlashCard();
            Category cat = new Category(_userID, categoryName);
            flashCard.Category = cat;

            if (!Database.Categories.Any(p => p.Name.ToUpper() == categoryName.ToUpper() && p.UserID == _userID))
            {
                Console.WriteLine("(Optional) Enter description for the category or press any key to skip it:");
                Console.Write(">>> ");
                cat.Desc = Console.ReadLine();
                flashCard.Category.Desc = cat.Desc;
                Database.Categories.Add(cat);
            }
            //else
            //{
            //    flashCard.Category.Name = categoryName;
            //}

            flashCard.UserID = _userID;
            flashCard.Question = question;
            flashCard.Answer = answer;
            Database.FlashCards.Add(flashCard);
            Console.WriteLine("You have successfully added a flash card!");
        }

        private string getYorN(string message)
        {
            Console.WriteLine(message);
            Console.Write(">>> ");
            string response = Console.ReadLine().ToUpper();
            if (response == "Y" || response == "N")
                return response;
            else return getYorN(message);
        }

    }
}
