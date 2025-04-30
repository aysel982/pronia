using Microsoft.EntityFrameworkCore;
using Pronia.DAL;

namespace Pronia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-R3G5OPM\\SQLEXPRESS;database=Pronia;Trusted_Connection=True; TrustServerCertificate=true;");
            });
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
                "deafult",
                "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
