using Microsoft.EntityFrameworkCore;
using WSventas.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<VentaRealContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("WSVentasDb"));
});
builder.Services.AddCors(crs => crs.AddPolicy("corsPolity", build=>{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsPolity");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
