namespace InnstantBook.Models
{
    public class ReservaModel
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int QuartoId { get; set; }
        public int ClienteId { get; set; }

    }
}
