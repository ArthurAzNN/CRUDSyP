using Microsoft.EntityFrameworkCore;
using ProjetoPI.Data;
using ProjetoPI.Interface;
using ProjetoPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ProdutoService : IProdutoService
{
    private readonly ApplicationDbContext _context;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(ApplicationDbContext context, IUsuarioRepository usuarioRepository, IProdutoRepository produtoRepository)
    {
        _context = context;
        _usuarioRepository = usuarioRepository;
        _produtoRepository = produtoRepository;
    }

    // Métodos CREATE
    public async Task<Roupa> PostarRoupaAsync(Roupa roupa)
    {
        var usuarioExistente = _usuarioRepository.GetUsuarioById(roupa.DoadorId);

        if (usuarioExistente == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        _context.Roupas.Add(roupa);
        await _context.SaveChangesAsync();

        return roupa;
    }

    public async Task<Livro> PostarLivroAsync(Livro livro)
    {
        var usuarioExistente = _usuarioRepository.GetUsuarioById(livro.DoadorId);

        if (usuarioExistente == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();

        return livro;
    }

    public async Task<Calcado> PostarCalcadoAsync(Calcado calcado)
    {
        var usuarioExistente = _usuarioRepository.GetUsuarioById(calcado.DoadorId);

        if (usuarioExistente == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        _context.Calcados.Add(calcado);
        await _context.SaveChangesAsync();

        return calcado;
    }

    // Métodos READ
    public async Task<Roupa> GetRoupaByIdAsync(int id)
    {
        return await _context.Roupas.FindAsync(id);
    }

    public async Task<List<Roupa>> GetAllRoupasAsync()
    {
        return await _context.Roupas.ToListAsync();
    }

    public async Task<Livro> GetLivroByIdAsync(int id)
    {
        return await _context.Livros.FindAsync(id);
    }

    public async Task<List<Livro>> GetAllLivrosAsync()
    {
        return await _context.Livros.ToListAsync();
    }

    public async Task<Calcado> GetCalcadoByIdAsync(int id)
    {
        return await _context.Calcados.FindAsync(id);
    }

    public async Task<List<Calcado>> GetAllCalcadosAsync()
    {
        return await _context.Calcados.ToListAsync();
    }

    // Métodos UPDATE
    public async Task<Roupa> AtualizarRoupaAsync(int id, Roupa roupaAtualizada)
    {
        var roupaExistente = await _context.Roupas.FindAsync(id);

        if (roupaExistente == null)
            throw new Exception("Roupa não encontrada.");

        // Atualiza os campos necessários
        roupaExistente.Nome = roupaAtualizada.Nome;
        roupaExistente.Tamanho = roupaAtualizada.Tamanho;
        roupaExistente.Cor = roupaAtualizada.Cor;

        await _context.SaveChangesAsync();
        return roupaExistente;
    }

    public async Task<Livro> AtualizarLivroAsync(int id, Livro livroAtualizado)
    {
        var livroExistente = await _context.Livros.FindAsync(id);

        if (livroExistente == null)
            throw new Exception("Livro não encontrado.");

        livroExistente.Titulo = livroAtualizado.Titulo;
        livroExistente.Autor = livroAtualizado.Autor;
        livroExistente.ISBN = livroAtualizado.ISBN;

        await _context.SaveChangesAsync();
        return livroExistente;
    }

    public async Task<Calcado> AtualizarCalcadoAsync(int id, Calcado calcadoAtualizado)
    {
        var calcadoExistente = await _context.Calcados.FindAsync(id);

        if (calcadoExistente == null)
            throw new Exception("Calçado não encontrado.");

        calcadoExistente.Tamanho = calcadoAtualizado.Tamanho;
        calcadoExistente.Cor = calcadoAtualizado.Cor;

        await _context.SaveChangesAsync();
        return calcadoExistente;
    }

    // Métodos DELETE
    public async Task<bool> DeletarRoupaAsync(int id)
    {
        var roupa = await _context.Roupas.FindAsync(id);

        if (roupa == null)
            return false;

        _context.Roupas.Remove(roupa);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletarLivroAsync(int id)
    {
        var livro = await _context.Livros.FindAsync(id);

        if (livro == null)
            return false;

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletarCalcadoAsync(int id)
    {
        var calcado = await _context.Calcados.FindAsync(id);

        if (calcado == null)
            return false;

        _context.Calcados.Remove(calcado);
        await _context.SaveChangesAsync();
        return true;
    }
}
