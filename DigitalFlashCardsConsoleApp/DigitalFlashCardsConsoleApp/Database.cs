using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalFlashCardsConsoleApp
{
    class Database
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static List<FlashCard> FlashCards { get; set; } = new List<FlashCard>();
        public static HashSet<Category> Categories { get; set; } = new HashSet<Category>();
    }
}
