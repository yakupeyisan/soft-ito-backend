using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleAPI.Business.Abstracts;
using ExampleAPI.Core.Abstracts;
using ExampleAPI.Entities;
using ExampleAPI.Integrations;
using ExampleAPI.Repositories.Abstracts;
using ExampleAPI.Repositories.Concretes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExampleAPI.Controllers;

[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(
        IUserService userService)
    {
        _userService=userService;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_userService.GetAll());
    }
    [HttpGet("GetAllWithBalanceTransactions")]
    public IActionResult GetAllWithBalanceTransactions()
    {
        return Ok(_userService.GetAll(
            include:user=>user.Include(u=>u.AccountTransactions)
            ));
    }
    [HttpGet("GetAllWithOrders")]
    public IActionResult GetAllWithOrders()
    {
        return Ok(_userService.GetAll(
            include: user => user
                    .Include(u => u.Orders).ThenInclude(o=>o.OrderDetails).ThenInclude(od=>od.ProductTransaction)
                    .Include(u=>u.Orders).ThenInclude(o=>o.OrderDetails).ThenInclude(od=>od.Product).ThenInclude(p=>p.Category)
            ));
    }
    [HttpGet("GetAllWithAllDetails")]
    public IActionResult GetAllWithAllDetails()
    {
        return Ok(_userService.GetAll(
            include: user => user
                    .Include(u => u.Orders).ThenInclude(o => o.OrderDetails).ThenInclude(od => od.ProductTransaction)
                    .Include(u => u.Orders).ThenInclude(o => o.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.Category)
                    .Include(u=>u.AccountTransactions)
            ));
    }

    [HttpGet("GetById/{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(_userService.Get(user=>user.Id==id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] User user)
    {
        return Ok(_userService.Add(user));
    }
    [HttpPost("AddBalance")]
    public IActionResult AddBalance([FromBody] AccountTransaction accountTransaction)
    {
        return Ok(_userService.AddBalance(accountTransaction));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] User user)
    {
        return Ok(_userService.Update(user));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult Delete(Guid id)
    {
        _userService.DeleteById(id);
        return Ok();
    }
}

