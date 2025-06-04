using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .HasColumnName("Name");

            // --------- Carregando Dados com Seed Data ----------
            builder.HasData(
               // ----- Italy (CountryId = 1) -----
               new City { Id = 1, Name = "Milan", CountryId = 1 },

               // ----- Spain (CountryId = 2) ------
               new City { Id = 2, Name = "Barcelona", CountryId = 2 },

               // ----- France (CountryId = 3) -----
               new City { Id = 3, Name = "Lyon", CountryId = 3 },

               // ----- United States (CountryId = 4) -----
               new City { Id = 4, Name = "Los Angeles", CountryId = 4 }
           );
            // ---------------------------------------------------
        }
    }
}
