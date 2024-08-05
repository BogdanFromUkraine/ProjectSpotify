using Microsoft.EntityFrameworkCore;
using ProjectTrackingSpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectTrackingSpotify.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TokenResult> TokenResults { get; set; }
        public DbSet<TopItems> TopItems { get; set; }

        public DbSet<UrlSpotify> UrlSpotify { get; set; }
       
    }

}

