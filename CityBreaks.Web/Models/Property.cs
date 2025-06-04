using System;
using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Web.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
        public decimal PricePerNight { get; set; }

        [Required(ErrorMessage = "Selecione uma cidade")]
        public int CityId { get; set; }

        public City City { get; set; } = null!;

        public DateTime? DeletedAt { get; set; }
    }
}
