using Microsoft.EntityFrameworkCore;
using P1_HangfireProject.Core.Contexts.Data;
using P1_HangfireProject.DataAccess.Abstract;
using P1_HangfireProject.DataAccess.Concrete;
using P1_HangfireProject.Business.Abstract;
using P1_HangfireProject.Business.Concrete;
using P1_HangfireProject.Hangfires.Abstract;
using P1_HangfireProject.Hangfires.Concrete;
using P1_HangfireProject.Hangfires;
using Hangfire;
using P1_HangfireProject.DataAccess.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjectDbContext>(x => 
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddHangfire(x =>
    x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddHangfireServer();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IExchangeService, ExchangeService>();
builder.Services.AddScoped<IExchangeServiceDal, ExchangeServiceDal>();
builder.Services.AddScoped<IHangfireInfo, HangfireInfo>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductServiceDal, ProductServiceDal>();
builder.Services.AddScoped<IBulkService, BulkService>();
builder.Services.AddScoped<BulkQueries>();

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

app.UseHangfireDashboard();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#pragma warning disable CS0618 // Type or member is obsolete
RecurringJob.AddOrUpdate<HandleHangfire>(x => x.Test(), Cron.MinuteInterval(5));
// RecurringJob.AddOrUpdate<HandleHangfire>(x => x.RefreshProductPrices(), Cron.MinuteInterval(5));

app.Run();
