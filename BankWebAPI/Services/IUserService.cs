using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWebAPI.Context;
using BankWebAPI.Models;
using BankWebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BankWebAPI.Services
{
   public interface IUserService
   {
       Task CreateAsync(UserCreateViewModel userCreateViewModel);
       Task<bool> CheckUserExist(UserCreateViewModel userCreateViewModel);
       Task<IEnumerable<User>> GetAllAsync();
   }

   public class UserService : IUserService
   {
       private readonly AppDataContext _context;

       public UserService(AppDataContext context)
       {
           _context = context;
       }

       public async Task CreateAsync(UserCreateViewModel ucvm)
       {
          User user=new User
          {
              Login = ucvm.Login,
              Password = ucvm.Login,
              Email = ucvm.Email,
              DateBirth = ucvm.DateBirth,
              Name = ucvm.Name,
              PassportNumber = ucvm.PassportNumber,
              Surname = ucvm.Surname
          };
          await _context.AddAsync(user);
          await _context.SaveChangesAsync();
       }

       public async Task<bool> CheckUserExist(UserCreateViewModel ucvm)
       {
           var user = await _context.Users
               .FirstOrDefaultAsync(u => u.Login == ucvm.Login||
                                         u.Email==ucvm.Email||
                                         u.PassportNumber==ucvm.PassportNumber);
           if (user != null)
           {
               return true;
           }
           return false;
       }

       public async Task<IEnumerable<User>> GetAllAsync()
       {
           return await _context.Users.ToListAsync();
       }
   }
}
