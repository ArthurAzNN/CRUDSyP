using ProjetoPI.Data;
using ProjetoPI.Interface;
using ProjetoPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoPI.Repository
{
    public class OngRepository : IOngRepository
    {
        private readonly ApplicationDbContext _context;

        public OngRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Criação (Create)
        public void AdicionarOng(Ong ong)
        {
            _context.Ongs.Add(ong);
            _context.SaveChanges(); // Salva as alterações no banco de dados
        }

        // Leitura (Read) - Obter ONG por e-mail
        public Ong GetOngByEmail(string email)
        {
            return _context.Ongs.FirstOrDefault(o => o.Email == email);
        }

        // Leitura (Read) - Obter todas as ONGs
        public List<Ong> GetAllOngs()
        {
            return _context.Ongs.ToList();
        }

        // Leitura (Read) - Contar total de ONGs
        public int GetQuantidadeOngs()
        {
            return _context.Ongs.Count();
        }

        // Atualização (Update)
        public void AtualizarOng(Ong ong)
        {
            _context.Ongs.Update(ong);
            _context.SaveChanges();
        }

        // Remoção (Delete)
        public void RemoverOng(int id)
        {
            var ong = _context.Ongs.FirstOrDefault(o => o.Id == id);
            if (ong != null)
            {
                _context.Ongs.Remove(ong);
                _context.SaveChanges();
            }
        }
    }
}
