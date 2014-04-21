using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TwentyOneDayApp.Models
{
    public class ModelContext : DbContext
    {
        static ModelContext()
        {
            Database.SetInitializer<ModelContext>(null);
        }

        public static void SetDatabaseInitializer(IDatabaseInitializer<ModelContext> initializer)
        {
            Database.SetInitializer<ModelContext>(initializer);
        }

        public ModelContext()
            : this("default")
        {
        }

        public ModelContext(string connName)
            : base(connName)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ContainerCollection> ContainerCollections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Container>();

            //base.OnModelCreating(modelBuilder);
        }
    }
}