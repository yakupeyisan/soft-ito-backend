using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;
using ExampleAPI.Repositories.Concretes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExampleAPI.Controllers;

[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly IAccountTransactionRepository _accountTransactionRepository;

    public UsersController(
        IUserRepository userRepository,
        IAccountTransactionRepository accountTransactionRepository)
    {
        _userRepository = userRepository;
        _accountTransactionRepository = accountTransactionRepository;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_userRepository.GetAll());
    }
    [HttpGet("GetAllWithBalanceTransactions")]
    public IActionResult GetAllWithBalanceTransactions()
    {
        return Ok(_userRepository.GetAll(
            include:user=>user.Include(u=>u.AccountTransactions)
            ));
    }
    [HttpGet("GetAllWithOrders")]
    public IActionResult GetAllWithOrders()
    {
        return Ok(_userRepository.GetAll(
            include: user => user
                    .Include(u => u.Orders).ThenInclude(o=>o.OrderDetails).ThenInclude(od=>od.ProductTransaction)
                    .Include(u=>u.Orders).ThenInclude(o=>o.OrderDetails).ThenInclude(od=>od.Product).ThenInclude(p=>p.Category)
            ));
    }
    [HttpGet("GetAllWithAllDetails")]
    public IActionResult GetAllWithAllDetails()
    {
        return Ok(_userRepository.GetAll(
            include: user => user
                    .Include(u => u.Orders).ThenInclude(o => o.OrderDetails).ThenInclude(od => od.ProductTransaction)
                    .Include(u => u.Orders).ThenInclude(o => o.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.Category)
                    .Include(u=>u.AccountTransactions)
            ));
    }

    [HttpGet("GetById/{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(_userRepository.Get(user=>user.Id==id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] User user)
    {
        return Ok(_userRepository.Add(user));
    }
    [HttpPost("AddBalance")]
    public IActionResult Add([FromBody] AccountTransaction accountTransaction)
    {
        return Ok(_accountTransactionRepository.Add(accountTransaction));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] User user)
    {
        return Ok(_userRepository.Update(user));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult Delete(Guid id)
    {
        var user = _userRepository.Get(user => user.Id == id);
        if (user == null) return BadRequest("User not found");
        return Ok(_userRepository.Delete(user));
    }
}

