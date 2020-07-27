using LiveCore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiveCore.Infrastructure.Database
{
    public class MyContext :DbContext  
    {   
        public MyContext(DbContextOptions<MyContext> options)
         : base(options)
        {

        }

        public DbSet<User> Users {get;set;}
    }
}