using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class HelpDeskContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<Game> Games { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<GameModels.Genre> Genres { get; set; }
        public DbSet<GameModels.OS> OS { get; set; }
        public DbSet<GameModels.CPU> CPUs { get; set; }
        public DbSet<GameModels.RAM> RAMs { get; set; }
        public DbSet<GameModels.VideoCard> VideoCards { get; set; }
        public DbSet<GameModels.DirectX> DirectXes { get; set; }
    }
}