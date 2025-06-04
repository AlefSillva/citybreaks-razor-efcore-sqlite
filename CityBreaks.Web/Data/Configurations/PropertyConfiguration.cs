using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .HasColumnName("Name");

            // --------- Carregando Dados com Seed Data ----------
            builder.HasData(
                // ----- Milan (CityId = 1) -----
                new Property { Id = 1, Name = "Milan Downtown Loft", PricePerNight = 200m, CityId = 1 },

                // ----- Barcelona (CityId = 2) -----
                new Property { Id = 2, Name = "Barcelona Sea View Apartment", PricePerNight = 180m, CityId = 2 },

                // ----- Lyon (CityId = 3) -----
                new Property { Id = 3, Name = "Lyon City Center Flat", PricePerNight = 150m, CityId = 3 },

                // ----- Los Angeles (CityId = 4) -----
                new Property { Id = 4, Name = "LA Modern Studio", PricePerNight = 220m, CityId = 4 }
            );
            // ---------------------------------------------------
        }
    }
}
