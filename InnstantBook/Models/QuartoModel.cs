using InnstantBook.Enums;

namespace InnstantBook.Models
{
    public class QuartoModel
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public decimal Preco { get; set; }
        public StatusQuarto Status { get; set; }
        public int HotelId { get; set; }

    }
}
