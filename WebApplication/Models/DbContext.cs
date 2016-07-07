using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class HelpDeskContext : DbContext
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<Game> Games { get; set; }
    }
}