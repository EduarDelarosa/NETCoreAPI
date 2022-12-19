using Proyecto.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Ecommerce.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);
    }
}
