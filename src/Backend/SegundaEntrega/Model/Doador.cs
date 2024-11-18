using ProjetoPI.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPI.Model
{
    public class Doador : Usuario
    {
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; } // Propriedade pública para CPF

        [Required]
        public DateTime DataNascimento { get; set; } // Data de nascimento do doador

        [Required]
        public DateTime DataCadastro { get; set; } = DateTime.Now; // Define automaticamente a data atual

        [NotMapped] // Ignorar no banco, pois é derivado de `DataNascimento`
        public string DataNascimentoString => DataNascimento.ToString("yyyy-MM-dd");

        // Construtor padrão necessário para o EF
        public Doador() { }

        // Construtor opcional para inicialização explícita
        public Doador(string nome, string email, string senha, string endereco, string telefone, string cpf, DateTime dataNascimento)
            : base(nome, email, senha, endereco, telefone, TipoUsuario.Doador)
        {
            Cpf = cpf;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now; // Define automaticamente a data de cadastro
        }
    }
}
