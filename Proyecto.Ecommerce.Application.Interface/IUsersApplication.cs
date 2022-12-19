using Proyecto.Ecommerce.Application.DTO;
using Proyecto.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Ecommerce.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDTO> Authenticate(string username, string password);
    }
}
