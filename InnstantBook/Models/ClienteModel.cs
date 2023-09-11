using System.ComponentModel.DataAnnotations;

namespace InnstantBook.Models
{
    public class ClienteModel
    {
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF não está no formato correto.")]
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public string? IdsReservas { get; set; }
    }
}
