using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TodoApi.AppDataContext;
using TodoApi.Interface;
using TodoApi.Middleware;
using TodoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddTransient<ITodoService, TodoService>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddProblemDetails();  // Add this line

// Adding of login 
builder.Services.AddLogging();  //  Add this line

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Todo API");
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapControllers();

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     try
//     {
//         var context = services.GetRequiredService<TodoDbContext>();
//         await DbInitializer.Initialize(context); // Call your static or injected seeder method
//     }
//     catch (Exception ex)
//     {
//         var logger = services.GetRequiredService<ILogger<Program>>();
//         logger.LogError(ex, "An error occurred while seeding the database.");
//     }
// }

app.Run();
