using AutoMapper;
using Proyecto.Ecommerce.Application.DTO;
using Proyecto.Ecommerce.Application.Interface;
using Proyecto.Ecommerce.Domain.Interface;
using Proyecto.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Ecommerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
        }

        public Response<UsersDTO> Authenticate(string username, string password)
        {
            var response = new Response<UsersDTO>();
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "No se admiten valores vacios";
                return response;
            }

            try
            {
                var user = _usersDomain.Authenticate(username, password);
                // Indicamos el destino <destino> y el origen entre parentesis (origen) qe es el resultado que nos regresa la capa de dominio
                response.Data = _mapper.Map<UsersDTO>(user);
                response.IsSuccess = true;
                response.Message = "Autenticacion exitosa!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "El usuario no existe";
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }

            return response;
        }
    }
}
