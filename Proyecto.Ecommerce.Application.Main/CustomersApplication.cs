using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Proyecto.Ecommerce.Application.DTO;
using Proyecto.Ecommerce.Application.Interface;
using Proyecto.Ecommerce.Domain.Entity;
using Proyecto.Ecommerce.Domain.Interface;
using Proyecto.Ecommerce.Transversal.Common;

namespace Proyecto.Ecommerce.Application.Main
{
    public class CustomersApplication : ICustomerApplication
    {
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;
        public CustomersApplication(ICustomersDomain customersDomain, IMapper mapper, IAppLogger<CustomersApplication> logger)
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
            _logger = logger;
        }

        #region Metodos Sincronos
        public Response<bool> Insert(CustomersDTO customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customers = _mapper.Map<Customers>(customerDto);
                response.Data = _customersDomain.Insert(customers);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitosos";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
        public Response<bool> Update(CustomersDTO customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customers = _mapper.Map<Customers>(customerDto);
                response.Data = _customersDomain.Update(customers);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customersDomain.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
        public Response<CustomersDTO> GetById(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = _customersDomain.GetById(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
        public Response<IEnumerable<CustomersDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customer = _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        #endregion

        #region Metodos Asincronos
        public async Task<Response<bool>> InsertAsync(CustomersDTO customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customers = _mapper.Map<Customers>(customerDto);
                response.Data = await _customersDomain.InsertAsync(customers);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitosos";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
        public async Task<Response<bool>> UpdateAsync(CustomersDTO customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customers = _mapper.Map<Customers>(customerDto);
                response.Data = await _customersDomain.UpdateAsync(customers);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customersDomain.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
        public async Task<Response<CustomersDTO>> GetByIdAsync(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = await _customersDomain.GetByIdAsync(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
        public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customer = await _customersDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                    _logger.LogInformation("Consulta Exitosa!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }

        #endregion 
    }
}
