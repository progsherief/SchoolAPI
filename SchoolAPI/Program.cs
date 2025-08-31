using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using SchoolAPI.Interfaces;
using SchoolAPI.Models;
using SchoolAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder
  .Services
  .Configure<SchoolDatabaseSettings>(
    builder.Configuration.GetSection("SchoolDatabaseSettings")
  );

builder.Services.AddSingleton<IMongoClient>(_ => {
    var connectionString =
        builder
            .Configuration
            .GetSection("SchoolDatabaseSettings:ConnectionString")?
            .Value;
    return new MongoClient(connectionString);
});


//builder.Services.AddSingleton<IMongoClient>(_ => {
//    var settings = new MongoClientSettings()
//    {
//        Scheme = ConnectionStringScheme.MongoDB,
//        Server = new MongoServerAddress("localhost", 27017)
//    };
//    return new MongoClient(settings);
//});

builder.Services.AddSingleton<IStudentService, StudentService>();
builder.Services.AddSingleton<ICourseService, CourseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
