
namespace LazyDI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IMyService, MyService>();

        builder.Services.AddscopedLazy<IMyService>();
        

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}


public static class AddServiceLazilyExtensions
{
    public static IServiceCollection AddscopedLazy<T>(this IServiceCollection services) where T : class
    {
        services.AddScoped<Lazy<T>>(provider =>
            new Lazy<T>(() => provider.GetRequiredService<T>()));

        return services;
    }
}