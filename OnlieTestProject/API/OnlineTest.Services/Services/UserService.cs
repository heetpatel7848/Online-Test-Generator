using OnlineTest.Model;
using OnlineTest.Model.Interfaces;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
        public List<UserDTO> GetUsers()
        {
            try
            {
                var users = _userRepository.GetUsers().Select(s => new UserDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    MobileNo = s.MobileNo,
                    Password = s.Password,
           
                    IsActive = s.IsActive
                }).ToList();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddUser(UserDTO user)
        {
            return _userRepository.AddUser(new User { Email = user.Email, MobileNo = user.MobileNo, Name = user.Name, Password = user.Password, IsActive = user.IsActive });
        }

        public bool UpdateUser(UserDTO user)
        {
            return _userRepository.UpdateUser(new User { Email = user.Email, MobileNo = user.MobileNo, Name = user.Name, Password = user.Password, IsActive = user.IsActive });
        }

        public bool DeleteUser(int Id)
        {
            return _userRepository.DeleteUser(Id);

        }
    }
}
