using System;

namespace DigitalFlashCardsConsoleApp
{
    public class Category
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public Category(int userID, string categoryName, string desc = "")
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                throw new ArgumentException("Category name cannot be blank.");
            UserID = userID;
            Name = categoryName;
            Desc = desc;
        }
       
    }
}