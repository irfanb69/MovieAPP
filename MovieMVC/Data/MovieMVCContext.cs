using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieMVC.Models;

namespace MovieMVC.Datas
{
    public class MovieMVCContext : DbContext
    {
        public MovieMVCContext (DbContextOptions<MovieMVCContext> options)
            : base(options)
        {
        }

        public DbSet<MovieMVC.Models.Movie> Movie { get; set; }
        public DbSet<Flugzeug> Flugzeugs { get; set; }
    }
}
