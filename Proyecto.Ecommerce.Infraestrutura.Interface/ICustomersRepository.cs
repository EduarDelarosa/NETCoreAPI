using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Ecommerce.Domain.Entity;

namespace Proyecto.Ecommerce.Infraestructura.Interface
{
    public interface ICustomersRepository
    {
        #region Metodos Sincronos
        bool Insert(Customers customer);
        bool Update(Customers customer);
        bool Delete(string customerId);
        Customers GetById(string customerId);
        IEnumerable<Customers> GetAll();

        #endregion

        #region Metodos Asincronos
        Task<bool> InsertAsync(Customers customer);
        Task<bool> UpdateAsync(Customers customer);
        Task<bool> DeleteAsync(string customerId);
        Task<Customers> GetByIdAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllAsync();

        #endregion 

    }
}
