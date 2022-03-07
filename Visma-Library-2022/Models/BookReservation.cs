using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;

namespace Visma_Library_2022.Models
{
    public class BookReservation: IUser
    {
        public int ReservationId { get; set; }

        [Key]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
