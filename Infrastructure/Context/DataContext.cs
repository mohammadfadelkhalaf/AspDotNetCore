using Infrastructure.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class DataContext:IdentityDbContext<UserEntity>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }
      //  public DbSet<UserEntity> Users { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<SubscriberEntity> Subscribers { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }

    }
}
