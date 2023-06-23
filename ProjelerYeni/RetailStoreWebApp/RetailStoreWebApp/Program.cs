using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RetailStoreWebApp.Business.Concrete;
using RetailStoreWebApp.Business.Abstract;
using RetailStoreWebApp.Core.Contexts.Data;
using RetailStoreWebApp.Core.Mapping;
using RetailStoreWebApp.DataAccess.Abstract;
using RetailStoreWebApp.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProjectDatabaseContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ICustomerServiceDal, CustomerServiceDal>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IProductServiceDal, ProductServiceDal>();
builder.Services.AddScoped<IProductService, ProductService>();

// Configure AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


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
