namespace Visma_Library_2022.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public bool IsAvailable { get; set; }
    }
}
