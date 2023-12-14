using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Question.Data;
using Microsoft.EntityFrameworkCore;
using QuestionFC.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<QuestionContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("QuestionContext") ?? throw new InvalidOperationException("Connection string 'QuestionContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    // Ajoutez le hub avec l'URL spécifiée
    endpoints.MapHub<QuestionHub>("/Hubs/QuestionHub"); 

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
