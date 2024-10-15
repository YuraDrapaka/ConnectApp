using ConnectAppAPI.DataAccess;
using ConnectAppAPI.DataAccess.Repositories;
using ConnectAppAPI.DataAccess.UnitOfWork;
using ConnectAppAPI.Services.Interfaces;
using ConnectAppAPI.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Connection string setup
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection3");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


// Registration UnitOfWork and Repositories
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IChatRepository, ChatRepository>();
//builder.Services.AddScoped<IMediaRepository, MediaRepository>();
//builder.Services.AddScoped<IMessageRepository, MessageRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();

// Registration of Services
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IChatService, ChatService>();
//builder.Services.AddScoped<IMessageService, MessageService>();
//builder.Services.AddScoped<IMediaService, MediaService>();








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
