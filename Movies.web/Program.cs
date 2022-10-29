using Microsoft.EntityFrameworkCore;
using Movies.DAL.Context;
using Movies.DAL.Interfaces;
using Movies.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Context 
builder.Services.AddDbContext<MoviesContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesContext")));



//Repositories

IServiceCollection services;


builder.Services.AddScoped<IClientsRepository, ClientRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IRentRepository, RentRepository>();



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Index}/{id?}");

app.Run();
