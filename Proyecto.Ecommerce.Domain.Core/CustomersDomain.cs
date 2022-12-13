using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Ecommerce.Domain.Entity;
using Proyecto.Ecommerce.Domain.Interface;
using Proyecto.Ecommerce.Infraestructura.Interface;

namespace Proyecto.Ecommerce.Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersDomain(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        #region Metodos sincronos
        public bool Insert(Customers customers)
        {
            return _customersRepository.Insert(customers);
        }
        public bool Update(Customers customers)
        {
            return _customersRepository.Update(customers);
        }
        public bool Delete(string customersId)
        {
            return _customersRepository.Delete(customersId);
        }
        public Customers GetById(string customerId)
        {
            return _customersRepository.GetById(customerId);
        }
        public IEnumerable<Customers> GetAll()
        {
            return _customersRepository.GetAll();
        }
        #endregion

        #region Metodos asincronos
        public async Task<bool> InsertAsync(Customers customers)
        {
            return await _customersRepository.InsertAsync(customers);
        }
        public async Task<bool> UpdateAsync(Customers customers)
        {
            return await _customersRepository.UpdateAsync(customers);
        }
        public async Task<bool> DeleteAsync(string customersId)
        {
            return await _customersRepository.DeleteAsync(customersId);
        }
        public async Task<Customers> GetByIdAsync(string customerId)
        {
            return await _customersRepository.GetByIdAsync(customerId);
        }
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _customersRepository.GetAllAsync();
        }
        #endregion
    }
}
