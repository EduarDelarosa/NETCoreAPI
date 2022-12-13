using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Ecommerce.Application.DTO;
using Proyecto.Ecommerce.Transversal.Common;

namespace Proyecto.Ecommerce.Application.Interface
{
    public interface ICustomerApplication
    {
        #region Metodos Sincronos
        Response<bool> Insert(CustomersDTO customerDto);
        Response<bool> Update(CustomersDTO customerDto);
        Response<bool> Delete(string customerId);
        Response<CustomersDTO> GetById(string customerId);
        Response<IEnumerable<CustomersDTO>> GetAll();

        #endregion

        #region Metodos Asincronos
        Task<Response<bool>> InsertAsync(CustomersDTO customerDto);
        Task<Response<bool>> UpdateAsync(CustomersDTO customerDto);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomersDTO>> GetByIdAsync(string customerId);
        Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync();

        #endregion 
    }
}
