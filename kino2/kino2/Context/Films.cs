
using kino2.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kino2.Context
{
    public class FilmsContext : DbContext
    {
        public DbSet<Film> films {get; set;}
    }
}
