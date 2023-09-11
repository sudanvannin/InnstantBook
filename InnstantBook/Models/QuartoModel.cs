using InnstantBook.Enums;
using System.ComponentModel.DataAnnotations;

namespace InnstantBook.Models
{
    public class QuartoModel
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public decimal Preco { get; set; }
        public StatusQuarto Status { get; set; }

        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido.")]
        public string HotelCNPJ { get; set; }

        public string? IdsReservas { get; set; }
    }
}
