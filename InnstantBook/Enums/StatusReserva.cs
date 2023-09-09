using System.ComponentModel;

namespace InnstantBook.Enums
{
    public enum StatusReserva
    {
        [Description("Em aberto")]
        EmAberto = 1,
        [Description("AguardandoPagamento")]
        AguardandoPagamento = 2,
        [Description("Reservado")]
        Reservado = 3,
    }
}
