using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReferenceApi;
using ReferenceApi.Helper;
using ReferenceApi.Managers;
using ReferenceApi.Repository;
using Serilog;
using Serilog.Events;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
    opt.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Scheme = "bearer"
    });
    opt.OperationFilter<AuthenticationRequirementsOperationFilter>();
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);
});

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IFillDbManager, FillDbManager>();
builder.Services.AddTransient<IForecastManager, ForecastManager>();
builder.Services.AddTransient<IRegistryManager, RegistryManager>();
builder.Services.AddTransient<ILoginManager, LoginManager>();

var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();


builder.Logging.ClearProviders();
var path = config.GetValue<string>("Logging:FilePath");
var logger = new LoggerConfiguration()
    .WriteTo.File(path)
    .CreateLogger();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}
app.UseSwagger();
app.UseSwaggerUI(/*options =>
{
    options.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
}*/);
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();


