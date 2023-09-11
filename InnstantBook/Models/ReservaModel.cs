using InnstantBook.Enums;
using System.ComponentModel.DataAnnotations;

namespace InnstantBook.Models
{
    public class ReservaModel
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public StatusReserva Status { get; set; }
        public int QuartoId { get; set; }

        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF não está no formato correto.")]
        public string ClienteCPF { get; set; }

    }
}
