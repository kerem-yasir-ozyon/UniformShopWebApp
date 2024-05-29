using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniformShop.ENTITIES.Concrete;

namespace Uniform.DAL.DataContext
{
    public class UniformShopDbContext : IdentityDbContext<AppUser,IdentityRole<int>,int>
    {
        public UniformShopDbContext(DbContextOptions<UniformShopDbContext> options) :base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
