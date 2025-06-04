using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(c => c.CountryName)
                .HasMaxLength(100)
                .HasColumnName("Name");

            builder.Property(c => c.CountryCode)
                .HasMaxLength(5)
                .HasColumnName("Code");

            // --------- Carregando Dados com Seed Data ----------
            builder.HasData(
                new Country { Id = 1, CountryName = "Italy", CountryCode = "IT"},
                new Country { Id = 2, CountryName = "Spain", CountryCode = "ES" },
                new Country { Id = 3, CountryName = "France", CountryCode = "FR"},
                new Country { Id = 4, CountryName = "United States", CountryCode = "US" }
            );
            //----------------------------------------------------
        }
    }
}
