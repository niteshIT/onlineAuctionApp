using Microsoft.EntityFrameworkCore;
using onlineActionApp.DLL.Data;
using onlineActionApp.DLL.IRepository;
using onlineActionApp.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineActionApp.DLL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuctionContext _context;

        public UserRepository(AuctionContext context)
        {
            _context = context;
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email && u.PasswordHash == password);
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }


        
    }
}
