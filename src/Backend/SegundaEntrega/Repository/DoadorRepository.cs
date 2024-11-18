using ProjetoPI.Data;
using ProjetoPI.Interface;
using ProjetoPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoPI.Repository
{
    public class DoadorRepository : IDoadorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoadorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Criação (Create)
        public void AdicionarDoador(Doador doador)
        {
            _context.Doadores.Add(doador);
            _context.SaveChanges(); // Salva as alterações no banco de dados
        }

        // Leitura (Read) - Obter doador por e-mail
        public Doador GetDoadorByEmail(string email)
        {
            return _context.Doadores.FirstOrDefault(d => d.Email == email);
        }

        // Leitura (Read) - Obter todos os doadores
        public List<Doador> GetAllDoadores()
        {
            return _context.Doadores.ToList();
        }

        // Leitura (Read) - Contar total de doadores
        public int GetQuantidadeDoadores()
        {
            return _context.Doadores.Count();
        }

        // Atualização (Update)
        public void AtualizarDoador(Doador doador)
        {
            _context.Doadores.Update(doador);
            _context.SaveChanges();
        }

        // Remoção (Delete)
        public void RemoverDoador(int id)
        {
            var doador = _context.Doadores.FirstOrDefault(d => d.Id == id);
            if (doador != null)
            {
                _context.Doadores.Remove(doador);
                _context.SaveChanges();
            }
        }
    }
}
