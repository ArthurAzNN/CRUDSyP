using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjetoPI.Enum;

namespace ProjetoPI.Model
{
    public abstract class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public EstadoProduto Estado { get; set; }

        [ForeignKey("Doador")]
        public int DoadorId { get; set; }

        public Doador? Doador { get; set; }

        // Propriedade Tipo que será usada para identificar o tipo de produto
        public Tipo Tipo { get; set; }

        // Construtor que aceita os parâmetros Descricao, Estado, DoadorId e Tipo
        public Produto(string descricao, EstadoProduto estado, int doadorId, Tipo tipo)
        {
            Descricao = descricao;
            Estado = estado;
            DoadorId = doadorId;
            Tipo = tipo;
        }

        // Construtor sem parâmetros (necessário para EF)
        public Produto() { }
    }

    // Enum para os estados do produto
    public enum EstadoProduto
    {
        Novo,
        Semiusado,
        Desgastado
    }

    // Enum para os tipos de produtos
    public enum Tipo
    {
        Calcado,
        Roupa,
        Eletronico
        // outros tipos...
    }
}
