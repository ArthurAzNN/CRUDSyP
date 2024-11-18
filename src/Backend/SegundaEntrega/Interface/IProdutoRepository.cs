using ProjetoPI.Model;

using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoPI.Model;

public interface IProdutoRepository
{
    // Método para adicionar um produto
    Task<int> AddProdutoAsync(Produto produto);

    // Método para obter um produto pelo ID
    Task<Produto?> GetProdutoByIdAsync(int id);

    // Método para listar todos os produtos
    Task<List<Produto>> GetAllProdutosAsync();

    // Método para atualizar um produto
    Task UpdateProdutoAsync(Produto produto);

    // Método para excluir um produto
    Task DeleteProdutoAsync(int id);
}
