using ProjectRPS;
using ProjectRPS.Core;
using ProjectRPS.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddGameState();
builder.Services.AddGameSystems();
builder.Services.AddGameLoop();
builder.Services.AddSignalRHub();
builder.Services.AddMessageSender();
builder.Services.AddMessageProcessors();
builder.Services.AddEntityBuilder();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithOrigins("http://localhost:5173");
});
app.MapControllers();
app.MapHub<MainHub>("mainHub");

var loop = app.Services.GetService<IGameLoop>();

loop.Start();
app.Run();