namespace LazyDI;

public class MyService : IMyService
{
    private readonly ILogger<MyService> _logger;

    public MyService(ILogger<MyService> logger)
    {
        _logger = logger;
        _logger.LogWarning("MyService Constructor");
    }

    public string SomeString()
    {
        _logger.LogInformation($"MyService {nameof(SomeString)}");
        return nameof(SomeString);
    }

}
