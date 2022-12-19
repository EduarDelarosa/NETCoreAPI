using Proyecto.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Ecommerce.Infraestructura.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string username, string password);
    }
}
