using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PostalService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(
    cfg => cfg.LicenseKey = "",
    typeof(MappingProfile)
);
builder.Services.AddDataAccess(builder.Configuration);

var app = builder.Build();

var mapper = app.Services.GetService<IMapper>();
try
{
    mapper.ConfigurationProvider.AssertConfigurationIsValid();
} catch (AutoMapperConfigurationException e)
{
    Console.WriteLine("Configuration exception: ", e.Message);
}


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
