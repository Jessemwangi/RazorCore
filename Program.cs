using Microsoft.EntityFrameworkCore;
using RazorCore.Infrastructures;
using RazorCore.Pages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var con = builder.Configuration["ConnectionStrings:DbConnection"];
builder.Services.AddDbContext<DataContext>(Options =>
{
    Options.UseSqlServer(con);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseMiddleware<TestSqlConnectionMiddleWare>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
