//using ConnectAppAPI.DataAccess.Repositories;
//using ConnectAppAPI.DataAccess.UnitOfWork;

using AppDbContextAPI.DataAccess;
using ConnectAppAPI.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registration Services
//builder.Services.AddScoped<IChatRepository, ChatRepository>();
//builder.Services.AddScoped<IMediaRepository, MediaRepository>();
//builder.Services.AddScoped<IMessageRepository, MessageRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


//// Налаштування рядка підключення
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//// Додавання контексту бази даних
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(connectionString));

//// Додавання UnitOfWork та сервісів
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IMessageService, MessageService>();

//// Інші конфігурації
//builder.Services.AddControllers();

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
