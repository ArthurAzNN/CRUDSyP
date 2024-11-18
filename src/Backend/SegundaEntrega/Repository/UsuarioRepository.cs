using Microsoft.EntityFrameworkCore;
using ProjetoPI.Data;
using ProjetoPI.Interface;
using ProjetoPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _context;

    public UsuarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Criação (Create)
    public async Task AdicionarUsuario(Usuario usuario)
    {
        if (await VerificarUsuarioExistente(usuario.Email))
        {
            throw new Exception("Usuário já existe com este e-mail.");
        }

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }

    // Leitura (Read)
    public Usuario GetUsuarioByEmail(string email)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Email == email);
    }

    public Usuario GetUsuarioByEmailSenha(string email, string senha)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
    }

    public Usuario GetUsuarioById(int id)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Id == id);
    }


    public List<Usuario> GetAllUsuarios()
    {
        return _context.Usuarios.ToList();
    }

    public int GetQuantidadeUsuarios()
    {
        return _context.Usuarios.Count();
    }

    public async Task<bool> VerificarUsuarioExistente(string email)
    {
        var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        return usuarioExistente != null;
    }

    // Atualização (Update)
    public async Task AtualizarUsuario(Usuario usuario)
    {
        var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuario.Id);

        if (usuarioExistente == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        // Atualize os dados necessários
        usuarioExistente.Nome = usuario.Nome;
        usuarioExistente.Email = usuario.Email;
        usuarioExistente.Senha = usuario.Senha;

        await _context.SaveChangesAsync();
    }


    // Exclusão (Delete)
    public async Task ExcluirUsuario(int id)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
    }
}