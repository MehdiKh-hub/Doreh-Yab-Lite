using Infra;
using Infra.Persistence;
using Infra.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using System;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI برای ریپوزیتوری‌ها و سرویس‌ها
builder.Services.AddInfrastructure(); 

// سایر سرویس‌ها...
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    context.Students.RemoveRange(context.Students);
    await context.SaveChangesAsync();

    await Seeder.SeedAsync(context);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}



app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.Run();
