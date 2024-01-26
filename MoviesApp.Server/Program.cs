using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MoviesApp.Server.Infastructure;
using MoviesApp.Server.Infastructure.Configurations;
using MoviesApp.Server.Infastructure.Repositories;
using MoviesApp.Server.Infastructure.Repositories.Interface;
using MoviesApp.Server.Service;
using MoviesApp.Server.Service.Interface;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddSwaggerGen(opts =>
{

    opts.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MoviesApp.Server",
        Version = "v1"
    });
    opts.CustomSchemaIds(x => x.FullName);
}
    );
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlite("Data Source=MovieDb.db"));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
    var seeder = new DataSeeder(dataContext);
    seeder.SeedData();
    dataContext.Database.Migrate();

}


app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
