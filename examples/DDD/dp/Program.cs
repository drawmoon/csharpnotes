using DomainPrimitive.Domain.Model.User;
using DomainPrimitive.Domain.Services;
using DomainPrimitive.EntityFrameworkCore;
using DomainPrimitive.EntityFrameworkCore.Repositories;
using DomainPrimitive.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var databaseName = Guid.NewGuid().ToString();
builder.Services
    .AddEntityFrameworkInMemoryDatabase()
    .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IUserFactory, UserFactory>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();

app.Run();