using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using crudApi.Models;

namespace crudApi.Repositories
{
   public interface IDao<TEntity,U> where TEntity : class
    {
        IEnumerable<TEntity> GetUsers();
        TEntity GetUser(U id);
        int AddUser(TEntity b);
    //    int UpdateUser(U id,TEntity b);
     //   int DeleteUser(U id); 
    }

    public class Dao : IDao<User, int>
    {
            DummyContext ctx;
            public Dao(DummyContext c)
            {
                        ctx = c;
            }

            public IEnumerable<User> GetUsers()
            {
                        var users = ctx.User.ToList();
                        return users;
            }


            public User GetUser(int id)
            {
                var user = ctx.User.Find(id);
                return user;
            }

            public int AddUser(User user)
            {
                ctx.User.Add(user);
                return ctx.SaveChanges();
            }
    }



}