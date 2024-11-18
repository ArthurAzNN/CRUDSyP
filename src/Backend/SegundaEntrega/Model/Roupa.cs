using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ProjetoPI.Model;

public class Roupa : Produto
{
    [Key] // Chave primária (herdada ou local)
    public int Id { get; set; }

    [Required(ErrorMessage = "O tipo de roupa é obrigatório.")]
    public TipoRoupa TipoRoupa { get; set; }

    [Required(ErrorMessage = "O tamanho da roupa é obrigatório.")]
    [StringLength(10, ErrorMessage = "O tamanho pode ter no máximo 10 caracteres.")]
    public string Tamanho { get; set; }

    [Required(ErrorMessage = "A cor da roupa é obrigatória.")]
    [StringLength(20, ErrorMessage = "A cor pode ter no máximo 20 caracteres.")]
    public string Cor { get; set; }

    // Construtor padrão necessário para EF
    public Roupa() { }

    // Construtor opcional para inicialização explícita
    public Roupa(TipoRoupa tipoRoupa, string tamanho, string cor)
    {
        TipoRoupa = tipoRoupa;
        Tamanho = tamanho;
        Cor = cor;
    }
}

public enum TipoRoupa
{
    Camisa,
    Calca,
    Sapato,
    Acessorio
}
