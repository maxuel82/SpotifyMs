using Microsoft.EntityFrameworkCore;
using SpotifyMs.Aplication.Conta;
using SpotifyMs.Aplication.Conta.Profile;
using SpotifyMs.Aplication.Streaming;
using SpotifyMS.Repository;
using SpotifyMS.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SpotifyMSContext>(c =>
{
    c.UseLazyLoadingProxies()
     .UseSqlServer(builder.Configuration.GetConnectionString("SpotifyConnection"));
});


/*Injeção de dependencia.*/
builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);


/*Repositories*/
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<PlanoRepository>();
builder.Services.AddScoped<BandaRepository>();

/*Services*/
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<BandaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
