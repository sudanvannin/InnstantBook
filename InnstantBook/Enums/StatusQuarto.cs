using System.ComponentModel;

namespace InnstantBook.Enums
{
    public enum StatusQuarto
    {
        [Description("Quarto Disponível")]
        Disponivel = 1,
        [Description("Quarto Indisponível")]
        Indisponivel = 2,
        [Description("Quarto Alugado")]
        Alugado = 3,
    }
}
