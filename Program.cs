using ContabilidadeBeatyBeach.Data;
using ContabilidadeBeatyBeach.Repository;
using ContabilidadeBeatyBeach.Repository.Interface;
using ContabilidadeBeatyBeach.Service;
using ContabilidadeBeatyBeach.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHoraExtraService, HoraExtraService>();
builder.Services.AddScoped<ICalculoSalarioService, CalculoSalarioService>();
builder.Services.AddScoped<IResumoMensalService, ResumoMensalService>();
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IResumoMensalRepository, ResumoMensalRepository>();
builder.Services.AddScoped<IHoraExtraRepository, HoraExtraRepository>();
builder.Services.AddScoped<IComissoesService, ComissoesService>();
builder.Services.AddScoped<IComissoesRepository, ComissoesRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
