using API.W.Movies.DataAccessLayer;
using API.W.Movies.MoviesMapper;
using API.W.Movies.Repository;
using API.W.Movies.Repository.IRepository;
using API.W.Movies.Services;
using API.W.Movies.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<Mappers>());

//Dependency Injection for Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMovieService, MovieService>();

//Dependency Injection for Repository
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//add-migration InitialDB
//update-database 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
