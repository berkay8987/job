using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RetailStoreWebApi.Core.Contexts.Data;
using RetailStoreWebApi.Core.Mapping;
using RetailStoreWebApi.DataAccess.Abstract;
using RetailStoreWebApi.DataAccess.Concrete;
using RetailStoreWebApi.Business.Abstract;
using RetailStoreWebApi.Business.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ProjectDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ICustomerServiceDal, CustomerServiceDal>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IProductServiceDal, ProductServiceDal>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IOrderServiceDal, OrderServiceDal>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IOrderDetailServiceDal, OrderDetailServiceDal>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();

// Configure AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
