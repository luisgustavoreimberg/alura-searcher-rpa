using AluraSearcherRPA.Application.Middlewares;
using AluraSearcherRPA.DependencyInjection;
using AluraSearcherRPA.Infrastructure.Logger;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var connectionString = builder.Configuration.GetConnectionString("DbConnection");
    ArgumentNullException.ThrowIfNull("Connection String");

    var chromeDriverPath = builder.Configuration.GetValue<string>("WebdriverPath");

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.ConfigureSwagger();
    builder.Services.ConfigureServices(chromeDriverPath);
    builder.Services.ConfigureDatabase(connectionString);

    var app = builder.Build();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ExceptionMiddleware>();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Log.Error("Erro na inicialização da aplicação", ex);
}
