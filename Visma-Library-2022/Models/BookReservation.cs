using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;

namespace Visma_Library_2022.Models
{
    public class BookReservation { 
        [Key]
        public int ReservationId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime DateTo { get; set; }

        public BookReservation()
        {

        }

        //public List<BookReservation> GetReservations(string connectionString)
        //{
        //    List<BookReservation> reservationList = new List<BookReservation>();
        //    SqlConnection con = new SqlConnection(connectionString);
        //    string selectSQL = "select ReservationId, UserId, BookId, DateTo from GetBookReservation";

        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(selectSQL, con);
        //}

        //public BookReservation GetBookReservation(string connectionString, int reservationId)
        //{

        //}

        //public void AddBookReservation(string connectionString, BookReservation bookReservation)
        //{

        //}

        //public void EditReservation(string connectionString, BookReservation bookReservation)
        //{

        //}

        //public void EditReservation(string connectionString, int reservationId)
        //{

        //}



    }
}
