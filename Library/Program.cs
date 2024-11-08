using LibraryCorner;
using LibraryCorner.Models;
using LibraryCorner.Models.ModelsRequest;
using LibraryCorner.Models.RequestModels;
using LibraryCorner.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    var conn = builder.Configuration["ConnectionStrings:SqlServer"];
    options.UseSqlServer(conn);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Author, RequestAuthor,AuthorRequest>, AuthorRepository>();
builder.Services.AddScoped<IRepository<Book, RequestBook,BookRequest>, BookRepository>();
builder.Services.AddScoped<IRepository<Library, RequestLibrary,LibraryRequest>, LibraryRepository>();
builder.Services.AddScoped<IRepository<User, RequestUser,UserRequest>, UserRepository>();
builder.Services.AddScoped<DataContext>();

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
