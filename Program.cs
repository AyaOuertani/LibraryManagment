using LibraryManagment.Data;
using Microsoft.EntityFrameworkCore;
using LibraryManagment.Interface;
using LibraryManagment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMemberService, MemberServices>();
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddDbContext<ApplicationDBcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
