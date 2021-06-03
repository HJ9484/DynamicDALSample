using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDALSample.DAL
{
    public class AppContext : DbContext
    {
        public System.Data.Entity.DbSet<Models.Share> shares { get; set; }
        public AppContext() : base("DefaultConnection")
        {
            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.CreateDatabaseIfNotExists<AppContext>());
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new Models.ShareConfiguration());






        }
    }
}
