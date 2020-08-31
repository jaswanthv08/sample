namespace sample.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class TruYumContext : DbContext
    {
        public TruYumContext()
            : base("name=TruYumContext")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Cart> Cart { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<MenuItem>()
                .Property(m=>m.Price)
                .IsRequired();
            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Name)
                .IsRequired();
           
        }
    }
}
