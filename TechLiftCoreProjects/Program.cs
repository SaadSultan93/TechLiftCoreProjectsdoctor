using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using TechLiftCoreProjects.Configuration;
using TechLiftCoreProjects.Data;
using TechLiftCoreProjects.Repositories;
using TechLiftCoreProjects.Services;
using Microsoft.AspNetCore.Identity;
using TechLiftCoreProjects.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// add dependencies to the application container
// dependecy name = context
/// email settings connect register
/// add transient... add scoped ... addd singleton
/// email service register
/// 
builder.Services.AddDbContext<ApplicationDBcontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("default")));
// identity register
builder.Services.AddDefaultIdentity<ProjectsUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBcontext>();
/// service register
/// 
builder.Services.AddScoped<IDoctorRep, DoctorRep>();
builder.Services.AddScoped<IEmailService, EmailService>();   
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

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
app.UseAuthentication();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
