using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApi.DBContexts
{
    public class DBContext : DbContext
    {
        //public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Player> Players { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Player> Player{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<Player>().ToTable("players"); // table name?

            // Configure Primary Keys  
            modelBuilder.Entity<Player>().HasKey(u => u.Id).HasName("id"); // field?

            // Configure indexes  
            modelBuilder.Entity<Player>().HasIndex(u => u.Name).HasDatabaseName("name");

            // Configure columns  
            modelBuilder.Entity<Player>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired(true);
            modelBuilder.Entity<Player>().Property(u => u.Name).HasColumnType("nvarchar(255)").IsRequired(true);
            modelBuilder.Entity<Player>().Property(u => u.Hints).HasColumnType("int").IsRequired(true);
            modelBuilder.Entity<Player>().Property(u => u.Turns).HasColumnType("int").IsRequired(true);
            modelBuilder.Entity<Player>().Property(u => u.status).HasColumnType("int").IsRequired(true);
            modelBuilder.Entity<Player>().Property(u => u.guid).HasColumnType("nvarchar(45)").IsRequired(true);
        }
    }
}
