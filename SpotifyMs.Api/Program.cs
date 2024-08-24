using IdentityServer4.AccessTokenValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Description = "Adicione o token JWT para fazer as requisições na APIs",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

});
builder.Services.AddDbContext<SpotifyMSContext>(c =>
{
    c.UseLazyLoadingProxies()
     .UseSqlServer(builder.Configuration.GetConnectionString("SpotifyConnection"));
});

/// conection string local apsetings.jason
/// "SpotifyConnection": "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True; Initial Catalog=SpotifyMsDatabase"

/*Injeção de dependencia.*/
builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);

builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:7108";
                    options.ApiName = "SpotifyMs-api";
                    options.ApiSecret = "SpotifyMsSecret";
                    options.RequireHttpsMetadata = true;
                });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("spotifylike-role-user", p =>
    {
        p.RequireClaim("role", "SpotifyMs-user");
    });
});

/*Repositories*/
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<PlanoRepository>();
builder.Services.AddScoped<BandaRepository>();
builder.Services.AddScoped<MusicaRepository>();
builder.Services.AddScoped<PlaylistRepository>();

/*Services*/
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<BandaService>();
builder.Services.AddScoped<MusicaService>();
builder.Services.AddScoped<PlaylistService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
