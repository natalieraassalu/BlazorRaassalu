using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abc.Data;

namespace movie.Data
{
    public class AbcSoftMovieContext : DbContext
    {
        public AbcSoftMovieContext (DbContextOptions<AbcSoftMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Abc.Data.movie> Movie { get; set; } = default!;
        public DbSet<Abc.Data.Currency> Currency { get; set; } = default!;
        public DbSet<Abc.Data.Country> Country { get; set; } = default!;
    }
}
