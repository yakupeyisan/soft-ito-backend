using ExampleAPI.Business.Abstracts;
using ExampleAPI.DTOs;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExampleAPI.Controllers;

[Route("api/[controller]")]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;

    public OrdersController(
        IOrderService orderService
        )
    {
        _orderService = orderService;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_orderService.GetAll());
    }
    [HttpGet("GetAllWithDetails")]
    public IActionResult GetAllWithDetails()
    {
        return Ok(_orderService.GetAll(include: order =>
        order.Include(o=>o.User)
            .Include(o => o.OrderDetails).ThenInclude(od=>od.Product).ThenInclude(p=>p.Category)
            .Include(o => o.OrderDetails).ThenInclude(od=>od.ProductTransaction)
            )
            
       );
    }

    [HttpGet("GetById/{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(_orderService.Get(order => order.Id == id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] AddOrderDto addOrderDto)
    {
        return Ok(_orderService.Add(addOrderDto));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Order order)
    {
        return Ok(_orderService.Update(order));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult Delete(Guid id)
    {
        _orderService.DeleteById(id);
        return Ok();
    }
}

