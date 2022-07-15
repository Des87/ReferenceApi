using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReferenceApi;
using ReferenceApi.Helper;
using ReferenceApi.Manager;
using ReferenceApi.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;
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
});


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IFillDbManager, FillDbManager>();
builder.Services.AddTransient<IForecastManager, ForecastManager>();
builder.Services.AddTransient<IRegistryManager, RegistryManager>();
builder.Services.AddTransient<ILoginManager, LoginManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(options =>
    //{
    //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    //    options.RoutePrefix = string.Empty;
    //});
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
