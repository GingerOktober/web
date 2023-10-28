using Microsoft.EntityFrameworkCore;
using webnet.Models;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WebContext>(options => options.UseSqlServer(connection));


builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();