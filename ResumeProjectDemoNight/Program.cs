using Microsoft.EntityFrameworkCore;
using ResumeProjectDemoNight.Context;

var builder = WebApplication.CreateBuilder(args);

// DB CONTEXT (ConnectionString buradan okunur)
builder.Services.AddDbContext<ResumeContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
