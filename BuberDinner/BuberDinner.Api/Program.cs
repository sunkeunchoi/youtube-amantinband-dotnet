using BuberDinner.Application;
using BuberDinner.Application.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}