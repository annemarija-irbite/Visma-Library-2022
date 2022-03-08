using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visma_Library_2022.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }

        [ForeignKey("Email")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime DateTo { get; set; }

        public Reservation(){}
    }
}
