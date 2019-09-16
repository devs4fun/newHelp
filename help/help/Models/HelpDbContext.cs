using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace help.Models
{
    public class HelpDbContext : DbContext
    {
        public HelpDbContext() : base("HelpDb")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}