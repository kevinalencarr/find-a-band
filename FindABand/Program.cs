using FindABand.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var sqlConBuilder = new SqlConnectionStringBuilder();

sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("SQLDbConnection");
sqlConBuilder.UserID = builder.Configuration["DbUserId"];
sqlConBuilder.Password = builder.Configuration["DbPassword"];

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlConBuilder.ConnectionString));

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    // Seed.SeedUsersAndRolesAsync(app);
    Seed.SeedData(app);
}

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
