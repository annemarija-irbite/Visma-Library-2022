using Microsoft.AspNetCore.Mvc;
using Visma_Library_2022.Models;

namespace Visma_Library_2022.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public ICollection<BorrowedBook> BorrowedBooks { get; set; }
        //public bool Available { get; set; }
        public Book(){}

        
    

        




    }
}
