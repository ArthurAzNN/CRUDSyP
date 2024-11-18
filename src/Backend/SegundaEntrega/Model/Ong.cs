using ProjetoPI.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoPI.Model
{
    public class Ong : Usuario
    {
        public int Id { get; set; } // ID único para cada ONG

        [Required]
        public string Cnpj { get; set; } // CNPJ da ONG

        public DateTime DataCadastro { get; set; } // Data de cadastro da ONG

        // Construtor padrão necessário para o EF
        public Ong() { }

        // Construtor opcional (caso você precise inicializar com parâmetros)
        public Ong(string nome, string email, string senha, string endereco, string telefone, string cnpj)
            : base(nome, email, senha, endereco, telefone, TipoUsuario.Ong)
        {
            this.Cnpj = cnpj;
            this.DataCadastro = DateTime.Now; // Define a data de cadastro como a data atual
        }
    }
}
