using OnlineTest.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using OnlineTest.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Model.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly OnlineTestContext _context;
        public UserRepository(OnlineTestContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public bool AddUser(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges() > 0;
        }
        public bool UpdateUser(User user)
        {
            //var entity= _context.Users.FirstOrDefault(u=>u.Id == user.Id);
            // if (entity!=null)
            // {
            //     entity.Name = user.Name;
            //     entity.Email = user.Email;
            //     entity.Password = user.Password;
            //     entity.MobileNo = user.MobileNo;
            // }
            _context.Update(user);
            return _context.SaveChanges() > 0;
        }
        public bool DeleteUser(int Id)
        {
            var entity = _context.Users.FirstOrDefault(u => u.Id == Id);
            if (entity != null)
            {
                _context.Users.Remove(entity);
            }
            return _context.SaveChanges() > 0;
        }
    }
}
