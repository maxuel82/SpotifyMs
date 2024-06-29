using Microsoft.EntityFrameworkCore;
using SpotifyMs.Aplication.Admin.Profile;
using SpotifyMs.Aplication.Admin;
using SpotifyMS.Repository;
using SpotifyMS.Repository.Repository;
using SpotifyMs.Aplication.Streaming;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SpotifyMSContext>(c =>
{
    c.UseLazyLoadingProxies()
     .UseSqlServer(builder.Configuration.GetConnectionString("SpotifyConnection"));
});

builder.Services.AddAutoMapper(typeof(UsuarioAdminProfile).Assembly);

builder.Services.AddScoped<UsuarioAdminRepository>();
builder.Services.AddScoped<UsuarioAdminService>();

builder.Services.AddScoped<BandaRepository>();
builder.Services.AddScoped<BandaService>();

builder.Services.AddScoped<MusicaRepository>();
builder.Services.AddScoped<MusicaService>();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
