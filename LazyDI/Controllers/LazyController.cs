using Microsoft.AspNetCore.Mvc;

namespace LazyDI.Controllers;
[ApiController]
[Route("[controller]")]
public class LazyController : ControllerBase
{
    
    private readonly ILogger<LazyController> _logger;
    private readonly Lazy<IMyService> _lazyService;// = new Lazy<IMyService>(() => new MyService());

    public LazyController(Lazy<IMyService> lazyService, ILogger<LazyController> logger)
    {
        this._lazyService = lazyService;
        _logger = logger;
    }

    [HttpGet]
    [Route("GetNothing")]
    public IActionResult GetNothing()
    {
        _logger.LogInformation(nameof(GetNothing));

        return Ok(nameof(GetNothing));
    }


    [HttpGet]
    [Route("GetLazy")]
    public IActionResult GetLazy()
    {
        var s = _lazyService.Value.SomeString();
        _logger.LogInformation(s);
        
        return Ok(s);
    }


}
