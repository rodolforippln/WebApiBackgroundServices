using WebApiBackgroundServices.Repository;
using WebApiBackgroundServices.Services;

var builder = WebApplication.CreateBuilder(args);

using IHost host = Host.CreateDefaultBuilder(args).Build();

//builder.Configuration

IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

//string con = config.GetValue<string>("ConnectionStrings:conn1");
//OR
string connectionString = config["ConnectionStrings:conn1"];

// var stringConexao = "User Id=SYSTEM;Password=1234;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST =localhost)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=XE)))";

Console.WriteLine($"Hello, World! {connectionString}");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

builder.Services.AddHttpClient<OrderClient>();
builder.Services.AddTransient<OrderService>();
builder.Services.AddSingleton<ICommandRepository, CommandRepository>();
builder.Services.AddHostedService<OrderWorker>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
