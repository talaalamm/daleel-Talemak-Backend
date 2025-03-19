using Microsoft.EntityFrameworkCore;
using SchoolsProject.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option =>
{ option.UseSqlServer(builder.Configuration.GetConnectionString("constr"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            //policy.WithOrigins("http://localhost:3000")
            policy.AllowAnyOrigin() // Allow all origins
            .AllowAnyMethod()  // Allow all HTTP methods (GET, POST, PUT, DELETE, etc.)
            .AllowAnyHeader(); // Allow all headers
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
