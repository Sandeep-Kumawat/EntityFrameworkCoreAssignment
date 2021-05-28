using DepartmentalStoreAppAPI.Application.RepositoryInterface;
using DepartmentalStoreAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Persistence.Repositories
{
    public class ProductRepository : GeneralRepository<Product>,IProductRepository
    {
        public ProductRepository(DepartmentalStoreContext context, ILogger<ProductRepository> logger) : base(context, logger)
        {

        }
        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<Product[]> GetAllProductAsync(bool includeInventory = false)
        {
            _logger.LogInformation($"Getting all Poduct");

            IQueryable<Product> query = _context.Product
                .Include(c => c.ProductDetail);

            if (includeInventory)
            {
                query = query
                  .Include(c => c.Inventory);

            }
            query = query.OrderByDescending(c => c.ProductId);
            return await query.ToArrayAsync();
        }
        public async Task<Product> GetAProductAsync(string name, bool includeInventory = false)
        {
            _logger.LogInformation($"Getting a Product for {name}");

            IQueryable<Product> query = _context.Product
               .Include(c => c.ProductDetail);

            if (includeInventory)
            {
                query = query
                  .Include(c => c.Inventory);

            }
            query = query.Where(c => c.ProductName == name);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Product> GetAProductAsyncByID(int id, bool includeInventory)
        {
            IQueryable<Product> query = _context.Product
               .Include(c => c.ProductDetail);

            if (includeInventory)
            {
                query = query
                  .Include(c => c.Inventory);

            }
            query = query.Where(c => c.ProductId == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
