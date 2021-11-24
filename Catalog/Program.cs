using Catalog.Repositories;
using Catalog.Settings;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

IConfiguration  Configuration = new();
//lets receive some things
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    var settings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
    return new MongoClient(settings.ConnectionString);
});

// Add services to the container. Only one copy because of singleton
builder.Services.AddSingleton<IItemsRepository, IMongoDbSettings>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
