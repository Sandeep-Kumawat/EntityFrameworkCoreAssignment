using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStoreAppAPI.Application.RepositoryInterface
{
    public interface IGeneralRepository<T> where T : class
    {
        void Add(T entity) ;
        void Delete(T entity);
        void Update(T entity);
    }
}
