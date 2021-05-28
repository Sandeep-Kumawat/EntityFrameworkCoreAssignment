using DepartmentalStoreAppAPI.Application.RepositoryInterface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Persistence.Repositories
{
    public class GeneralRepository<T> :IGeneralRepository<T> where T : class
    {
        protected readonly DepartmentalStoreContext _context;
        protected readonly ILogger<GeneralRepository<T>> _logger;

        public GeneralRepository(DepartmentalStoreContext context, ILogger<GeneralRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(T entity) 
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add<T>(entity);
        }

        public void Delete(T entity) 
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _context.Remove(entity);
        }
        public void Update(T entity)
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _context.Update<T>(entity);
           
        }

    }
}
