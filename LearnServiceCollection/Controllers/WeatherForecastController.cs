using Microsoft.AspNetCore.Mvc;

namespace LearnServiceCollection.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly Test Test;
    public TestController(Manager manager,Test test){
        this.Test=test;
    }

    [HttpGet(Name = "Get")]
    public IActionResult Get()
    {
        return Ok(this.Test.Get());
    }
}

