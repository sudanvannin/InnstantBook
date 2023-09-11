using System.ComponentModel.DataAnnotations;

namespace InnstantBook.Models
{
    public class AvaliacaoModel
    {
        public int Id { get; set; }
        public int Nota { get; set; }
        public string Comentario { get; set; }

        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido.")]
        public string HotelCNPJ { get; set; }
    }
}
