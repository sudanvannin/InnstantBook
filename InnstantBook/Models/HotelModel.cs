using System.ComponentModel.DataAnnotations;

namespace InnstantBook.Models
{
    public class HotelModel
    {
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido.")]
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }

        public string? IdsQuartos { get; set; }
        public string? IdsAvaliacoes { get; set; }
    }
}
