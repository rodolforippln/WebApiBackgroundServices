using WebApiBackgroundServices.Repository;
using WebApiBackgroundServices.Services;

var builder = WebApplication.CreateBuilder(args);

using IHost host = Host.CreateDefaultBuilder(args).Build();

//builder.Configuration

IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

//string con = config.GetValue<string>("ConnectionStrings:conn1");
//OR
string connectionString = config["ConnectionStrings:conn1"];

Console.WriteLine($"Hello, World! {connectionString}");

builder.Services.AddControllers();
builder.Services.AddHttpClient<OrderConsumerService>();
builder.Services.AddHttpClient<OrderConsumerById>();
builder.Services.AddHttpClient<OrderClient>();

builder.Services.AddSingleton<ICommandRepository, CommandRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
