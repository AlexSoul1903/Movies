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

builder.Services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));

//repositories
builder.Services.AddScoped<IClientsRepository, ClientRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IRentRepository, RentRepository>();
builder.Services.AddScoped<ISaleInvoiceRepository, SaleInvoiceRepository>();
builder.Services.AddScoped<IRentInvoiceRepository, RentInvoiceRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<IMoviesRepository, MovieRepository>();


//Services
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<ISaleInvoiceService, SaleInvoiceService>();
builder.Services.AddTransient<IRentInvoiceService, RentInvoiceService>();


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
