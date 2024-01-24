using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExampleAPI.Controllers;
[ApiController]
//api/Simple
[Route("api/[controller]")]
public class SimpleController : Controller
{
    //-- /Test
    [HttpGet("Test")]
    public string Test()=> "abc";
}

