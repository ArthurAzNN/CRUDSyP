using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ProjetoPI.Model;

public class Roupa : Produto
{
    [Key] // Chave prim�ria (herdada ou local)
    public int Id { get; set; }

    [Required(ErrorMessage = "O tipo de roupa � obrigat�rio.")]
    public TipoRoupa TipoRoupa { get; set; }

    [Required(ErrorMessage = "O tamanho da roupa � obrigat�rio.")]
    [StringLength(10, ErrorMessage = "O tamanho pode ter no m�ximo 10 caracteres.")]
    public string Tamanho { get; set; }

    [Required(ErrorMessage = "A cor da roupa � obrigat�ria.")]
    [StringLength(20, ErrorMessage = "A cor pode ter no m�ximo 20 caracteres.")]
    public string Cor { get; set; }

    // Construtor padr�o necess�rio para EF
    public Roupa() { }

    // Construtor opcional para inicializa��o expl�cita
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
