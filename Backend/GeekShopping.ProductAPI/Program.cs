using AutoMapper;
using GeekShopping.ProductAPI.Config;
using GeekShopping.ProductAPI.Model.Context;
using GeekShopping.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Connection with database
    var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");
    builder.Services.AddDbContext<MySQLContext>(options => 
    {
        options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 5)));
    });
#endregion

#region Configuring automapper injection  
    IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
    builder.Services.AddSingleton(mapper);
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region Dependency Injection
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
#endregion

#region CORS configuration
    var frontEndPolicy = "FrontEndPolicy";
    builder.Services.AddCors(options => 
    {
       options.AddPolicy(frontEndPolicy, policy =>
       {
            policy.WithOrigins("http://localhost:5173", "http://localhost:3000");
       }); 
    });
#endregion

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

// app.UseHttpsRedirection();

app.UseCors(frontEndPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
