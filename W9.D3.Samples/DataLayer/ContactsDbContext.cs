using Microsoft.EntityFrameworkCore;
using W9.D3.Samples.DataLayer.Entities;

namespace W9.D3.Samples.DataLayer
{
    public class ContactsDbContext(DbContextOptions<ContactsDbContext> opt) : DbContext(opt)
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Contact>().HasQueryFilter(c => c.IsPublic);

            modelBuilder.Entity<Recipient>()
                .HasDiscriminator<int>("type")
                .HasValue<PhoneNumber>(0)
                .HasValue<Email>(1)
                ;

            modelBuilder.Entity<Company>()
                .ToTable("Companies")
                ;
            modelBuilder.Entity<Person>()
                .ToTable("People")
                ;
        }
    }
}
