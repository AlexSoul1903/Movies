using Microsoft.EntityFrameworkCore;
using Movies.DAL.Context;
using Movies.DAL.Interfaces;
using Movies.DAL.Repositories;
using Movies.Service.Contracts;
using Movies.Service.Services;

var builder = WebApplication.CreateBuilder(args);

//Context 
builder.Services.AddDbContext<MoviesContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesContext")));



//Repositories

IServiceCollection services;

//repositories
builder.Services.AddScoped<IClientsRepository, ClientRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IRentRepository, RentRepository>();
builder.Services.AddScoped<ISaleInvoiceRepository, SaleInvoiceRepository>();
builder.Services.AddScoped<IRentInvoiceRepository, RentInvoiceRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<IMoviesRepository, MovieRepository>();


//Services
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();



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
