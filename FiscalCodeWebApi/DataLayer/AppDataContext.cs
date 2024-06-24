using Microsoft.EntityFrameworkCore;

namespace FiscalCodeWebApi.DataLayer
{
    public class AppDataContext(DbContextOptions<AppDataContext> options, ILogger<AppDataContext> logger) : DbContext(options)
    {
        private readonly ILogger<AppDataContext> _logger = logger;

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            try {
                var cities = File.ReadAllLines(@"CsvData\comuniitaliani.csv")
                    .Skip(1)
                    .Select(l => l.Split(';'))
                    .Select(fields => new City {
                        Id = long.Parse(fields[4]),
                        CadastralCode = fields[19],
                        IsCapital = fields[13][0] == '1',
                        Name = fields[5],
                        ProvinceId = long.Parse(fields[2]),
                    });
                var provinces = File.ReadAllLines(@"CsvData\comuniitaliani.csv")
                    .Skip(1)
                    .Select(l => l.Split(';'))
                    .Select(fields => new Province { Id = long.Parse(fields[2]), Acronym = fields[14], Name = fields[11] })
                    .Distinct()
                    ;
                modelBuilder.Entity<Province>().HasData(provinces);
                modelBuilder.Entity<City>().HasData(cities);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Exception reading from file");
            }
        }
    }
}
