using Proyecto.Ecommerce.Domain.Entity;
using Proyecto.Ecommerce.Domain.Interface;
using Proyecto.Ecommerce.Infraestructura.Interface;

namespace Proyecto.Ecommerce.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;

        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Users Authenticate(string username, string password)
        {
            return _usersRepository.Authenticate(username, password);
        }
    }
}
