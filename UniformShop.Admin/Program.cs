using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Uniform.DAL.DataContext;
using UniformShop.ENTITIES.Concrete;

namespace UniformShop.Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddDbContext<UniformShopDbContext>(opt =>
            { 
                    opt.UseSqlServer(builder.Configuration.GetConnectionString("UniformAppDbStr"));
            });

            builder.Services.AddIdentityCore<AppUser>()
                            .AddDefaultTokenProviders()
                            .AddEntityFrameworkStores<UniformShopDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
