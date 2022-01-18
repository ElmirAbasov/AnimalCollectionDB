using Microsoft.EntityFrameworkCore;

namespace AnimalCollectionWithDB.Entitie
{
    public class Context : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }

        private string _connectionString = "server=localhost;database=AnimalCollection;user=elmo;password=fingermonkey;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(
                _connectionString,
                ServerVersion.AutoDetect(_connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalType>().HasData(
                new AnimalType
                {
                    ID = 1,
                    Name = "Insects"
                },
                new AnimalType
                {
                    ID = 2,
                    Name = "Sponge"
                },
                new AnimalType
                {
                    ID = 3,
                    Name = "Reptiles"
                },
                new AnimalType
                {
                    ID = 4,
                    Name = "Birds"
                },
                new AnimalType
                {
                    ID = 5,
                    Name = "Mammals"
                }
            );

            modelBuilder.Entity<Animal>().HasData(
                new Animal
                {
                    ID = 1,
                    AnimalTypeID = 1,
                    Name = "Black Widow Spider"
                },
                new Animal
                {
                    ID = 2,
                    AnimalTypeID = 2,
                    Name = "Stinker Sponge"
                },
                new Animal
                {
                    ID = 3,
                    AnimalTypeID = 3,
                    Name = "Lizard"
                },
                new Animal
                {
                    ID = 4,
                    AnimalTypeID = 4,
                    Name = "Chicken"
                },
                new Animal
                {
                    ID = 5,
                    AnimalTypeID = 5,
                    Name = "Cat"
                }
            );

        }

    }

}