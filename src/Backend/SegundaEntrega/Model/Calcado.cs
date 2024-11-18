using ProjetoPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjetoPI.Model
{
    public class Calcado : Produto
    {
        [Required]
        public TipoCalcado TipoCalcado { get; set; } // Enum representando o tipo de calçado.

        [Required]
        public int Tamanho { get; set; } // Tamanho do calçado.

        // Construtor padrão necessário para o EF
        public Calcado() { }

        // Construtor opcional para inicialização explícita
        public Calcado(string descricao, EstadoProduto estado, int doadorId, TipoCalcado tipoCalcado, int tamanho)
            : base(descricao, estado, doadorId, Tipo.Calcado) // Passando informações ao construtor da base.
        {
            TipoCalcado = tipoCalcado;
            Tamanho = tamanho;
        }
    }

    // Enum para o tipo de calçado
    public enum TipoCalcado
    {
        Casual,
        Esportivo,
        Sandalia,
        Bota
    }
}
