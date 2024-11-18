using ProjetoPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjetoPI.Model
{
    public class Usuario
    {
        [Key] // Define que esta propriedade é a chave primária
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 50 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(200, ErrorMessage = "O endereço pode ter no máximo 200 caracteres.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "Formato de telefone inválido.")]
        public string Telefone { get; set; }

        [Required]
        public TipoUsuario TipoUsuario { get; set; }

        // Construtor padrão necessário para EF
        public Usuario() { }

        // Construtor opcional para inicialização explícita
        public Usuario(string nome, string email, string senha, string endereco, string telefone, TipoUsuario tipoUsuario)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Endereco = endereco;
            Telefone = telefone;
            TipoUsuario = tipoUsuario;
        }

        // Construtor para login (apenas email e senha)
        public Usuario(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
    }
}
