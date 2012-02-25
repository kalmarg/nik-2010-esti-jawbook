using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace JawBook
{
    public class Db : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Jaw> Jaws { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
