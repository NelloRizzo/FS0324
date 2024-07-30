using Microsoft.EntityFrameworkCore;
using W9.D2.EFCRUD.DataLayer.Entities;

namespace W9.D2.EFCRUD.DataLayer
{
    public class BlogDbContext : DbContext
    {
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        private static IEnumerable<Author> GetAuthors(int count) =>
            Enumerable.Range(1, count)
                // Select -> trasforma un'informazione di input (i), in un altro tipo (Author)
                .Select(i => new Author {
                    Id = i,
                    Email = Faker.Internet.Email(),
                    FriendlyName = Faker.Name.FullName(),
                    Password = "password"
                });

        /// <summary>
        /// Viene eseguito quando viene richiamato il comando update-database
        /// </summary>
        /// <param name="modelBuilder">Gestore del modello dati.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // genera un numero casuale di autori
            var authors = GetAuthors(100);

            modelBuilder.Entity<Author>() // gestisce l'entità Author
                                          // popola la tabella con l'elenco di autori generato casualmente
                .HasData(authors);

        }
    }
}
