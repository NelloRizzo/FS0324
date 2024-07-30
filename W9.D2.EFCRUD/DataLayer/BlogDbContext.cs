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
                    Id = i, Email = $"email{i}@test.com", FriendlyName = $"Friendly name {i}", Password = "password"
                });
        private static IEnumerable<Article> GetArticles(int count, Author[] authors) {
            return Enumerable.Range(1, count)
                .Select(i => new Article {
                    Author = authors[Random.Shared.Next(authors.Length)],
                    Body = $"Corpo dell'articolo n. {i}",
                    Title = $"Titolo {i}",
                    PublishedAt = DateTime.Now,
                    Id = i,
                    Comments = Enumerable.Range(1, Random.Shared.Next(10))
                        .Select(n => new Comment {
                            Author = authors[Random.Shared.Next(authors.Length)],
                            Body = $"Commento n. {n} all'articolo n. {i}",
                            PublishedAt= DateTime.Now,
                            Id = n,
                        })
                });
        }

        /// <summary>
        /// Viene eseguito quando viene richiamato il comando update-database
        /// </summary>
        /// <param name="modelBuilder">Gestore del modello dati.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // genera un numero casuale di autori
            var authors = GetAuthors(Random.Shared.Next(10));

            modelBuilder.Entity<Author>() // gestisce l'entità Author
                // popola la tabella con l'elenco di autori generato casualmente
                .HasData(authors);
        }
    }
}
