using Crud.Domain;
using Crud.Grpc.Services;
using Crud.Repository;
using Crud.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connetctionString = builder.Configuration.GetConnectionString("ConnectionStrings");
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connetctionString));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
