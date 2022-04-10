using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BitWise.Data;
using BitWise.Areas.Identity.Data;
using BitWise.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAchievementsRepo, AchievementsRepo>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();
string? connection;

if (builder.Environment.IsDevelopment())
{
    connection = builder.Configuration.GetConnectionString("DefaultConnection");
    
}
else
{
    connection = Environment.GetEnvironmentVariable("connectionString");
    if (connection == null)
    {
        throw new Exception("Connection string Env variable couldn't be found");
    }
}
builder.Services.AddDbContext<BitWiseContext>(options =>
    options.UseNpgsql(connection));builder.Services.AddDefaultIdentity<BitWiseUser>(options => {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = true;
        })
    .AddEntityFrameworkStores<BitWiseContext>();

builder.Services.AddDbContext<CoursesDbContext>(options =>
    options.UseNpgsql(connection));


builder.Services.AddDataProtection()
                .PersistKeysToDbContext<BitWiseContext>();

builder.Services.AddDataProtection()
                .PersistKeysToDbContext<CoursesDbContext>();

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
app.MapRazorPages();


app.Run();
