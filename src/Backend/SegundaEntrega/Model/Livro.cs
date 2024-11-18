using System.ComponentModel.DataAnnotations;
using ProjetoPI.Model;

public class Livro : Produto
{
    [Required]
    [MaxLength(100)] // Limite de caracteres para o gênero
    public string Genero { get; set; }

    [Required]
    [MaxLength(100)] // Limite de caracteres para o nome do autor
    public string Autor { get; set; }

    [Required]
    [MaxLength(100)] // Limite de caracteres para a editora
    public string Editora { get; set; }

    // Construtor padrão necessário para o EF
    public Livro() { }

    // Construtor opcional para inicialização explícita
    public Livro(string genero, string autor, string editora)
    {
        Genero = genero;
        Autor = autor;
        Editora = editora;
    }
}
