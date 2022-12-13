using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Proyecto.Ecommerce.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
