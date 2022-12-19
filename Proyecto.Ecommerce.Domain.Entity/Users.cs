using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Ecommerce.Domain.Entity
{
    public class Users
    {
        public int UserId { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int UserName { get; set; }
        public int Password { get; set; }
        public int Token { get; set; }
    }
}
