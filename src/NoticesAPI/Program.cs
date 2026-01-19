using MassTransit;
using FluentValidation;
using FluentValidation.AspNetCore;
using Notices.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Notices.Domain.RepositoryInterfaces;
using Notices.Infrastructure.Database;
using Notices.Infrastructure.Extensions;
using Notices.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Notices API",
        Version = "v1"
    });

    var securityScheme = new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Description = "Paste JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    var securityRequirement = new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    };
    options.AddSecurityDefinition("Bearer", securityScheme);
    options.AddSecurityRequirement(securityRequirement);

});

//Authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Keycloak:Authority"];
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Keycloak:Authority"],
            ValidateAudience = false,
            ValidAudience = builder.Configuration["Keycloak:Audience"],
            ValidateLifetime = true
        };
    });

//Authorization
builder.Services.AddAuthorization();

//MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly);
});


//Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyMarker).Assembly, includeInternalTypes: true);

// Mass Transit
builder.Services.AddNoticeApiMassTransit(builder.Configuration);

// Auto Mapper
builder.Services.AddAutoMapper(typeof(Notices.Application.MappingProfiles.MapModelsOnResponses).Assembly);
builder.Services.AddAutoMapper(typeof(Notices.Application.MappingProfiles.MapRequestsOnModels).Assembly);
builder.Services.AddAutoMapper(typeof(Notices.Application.MappingProfiles.MapContractsOnModels).Assembly);


// Database Context
builder.Services.AddDbContext<NoticesDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<INoticeRepository, NoticeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<NoticesDbContext>();
db.Database.Migrate();

app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();