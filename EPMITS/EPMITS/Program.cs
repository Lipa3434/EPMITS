using Microsoft.EntityFrameworkCore;
using EPMITS.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireHealthcareProviderRole", policy => policy.RequireRole("HealthcareProvider"));
    options.AddPolicy("RequireCaregiverRole", policy => policy.RequireRole("Caregiver"));
});

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "appointments",
    pattern: "appointments/{action=Index}/{id?}",
    defaults: new { controller = "Appointments" });

app.MapControllerRoute(
    name: "Caregivers",
    pattern: "Caregivers/{action=Index}/{id?}",
    defaults: new { controller = "Caregivers" });

app.MapControllerRoute(
    name: "Medications",
    pattern: "Medications/{action=Index}/{id?}",
    defaults: new { controller = "Medications" });

app.MapControllerRoute(
    name: "Patients",
    pattern: "Patients/{action=Index}/{id?}",
    defaults: new { controller = "Patients" });

app.MapRazorPages();

app.Run();
