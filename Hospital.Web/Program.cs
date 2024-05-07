using Hospital.Repositories;
using Hospital.Repositories.Implemention;
using Hospital.Repositories.Interface;
using Hospital.Services;
using Hospital.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>
    (options => options.SignIn.RequireConfirmedAccount = true).AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IDbInitialize, DbInitialize>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IHospitalInfo, HospitalInfoServices>();
builder.Services.AddTransient<IRoomServices, RoomServices>();
builder.Services.AddTransient<IContactServices, ContactServices>();
builder.Services.AddRazorPages();
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
DataSedding();
app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{Area=Admin}/{controller=Hospitals}/{action=Index}/{id?}");

app.Run();
void DataSedding()
{
    using (var Scope = app.Services.CreateScope())
    {
        var dbInitialize = Scope.ServiceProvider.
            GetRequiredService<IDbInitialize>();
        dbInitialize.Initialize();
    }
}
