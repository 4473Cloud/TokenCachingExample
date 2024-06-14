using Microsoft.AspNetCore.Mvc;

namespace TokenCachingExample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class HomeController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return Ok(await authenticationService.GetToken());
    }
}