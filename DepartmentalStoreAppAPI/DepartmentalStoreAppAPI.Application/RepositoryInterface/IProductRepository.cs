using DepartmentalStoreAppAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Application.RepositoryInterface
{
    public interface IProductRepository : IGeneralRepository<Product>
    {
        Task<bool> SaveChangesAsync();
        Task<Product[]> GetAllProductAsync(bool includeInventory);
        Task<Product> GetAProductAsync(string name, bool includeInventory);
        Task<Product> GetAProductAsyncByID(int id, bool includeInventory);
        //Task<Product[]> GetAllProductByCategory();
       
    }
}
