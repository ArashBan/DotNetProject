using DotNetProject.Application.Contexts;
using DotNetProject.Application.Services;
using DotNetProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DotNetProjectDb");
builder.Services.AddScoped<IDataBaseContext, DatabaseContext>();
builder.Services.AddScoped<IAddNewProductService, AddNewProductService>();
builder.Services.AddDbContext<DatabaseContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;

    var context = service.GetRequiredService<DatabaseContext>();
    context.Database.MigrateAsync().Wait();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
