using MassTransit;
using Notices.Application;
using Microsoft.EntityFrameworkCore;
using Notices.Domain.RepositoryInterfaces;
using Notices.Infrastructure.Database;
using Notices.Infrastructure.Extensions;
using Notices.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly);
});

builder.Services.AddNoticeApiMassTransit(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Notices.Application.MappingProfiles.MapModelsOnResponses).Assembly);
builder.Services.AddAutoMapper(typeof(Notices.Application.MappingProfiles.MapRequestsOnModels).Assembly);
builder.Services.AddAutoMapper(typeof(Notices.Application.MappingProfiles.MapContractsOnModels).Assembly);

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

app.Run();