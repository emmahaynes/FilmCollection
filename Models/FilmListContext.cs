using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Emma Haynes 3-25-21
//Context file to set up database

namespace FilmCollection.Models
{
    public class FilmListContext : DbContext
    {
        public FilmListContext (DbContextOptions<FilmListContext> options) : base (options)
        {

        }

        public DbSet<FormResponse> FormResponses { get; set; }
    }
}
