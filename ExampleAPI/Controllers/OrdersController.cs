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
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IProductTransactionRepository _productTransactionRepository;

    public OrdersController(
        IOrderRepository orderRepository,
        IOrderDetailRepository orderDetailRepository,
        IProductTransactionRepository productTransactionRepository
        )
    {
        _orderRepository = orderRepository;
        _orderDetailRepository = orderDetailRepository;
        _productTransactionRepository = productTransactionRepository;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_orderRepository.GetAll());
    }
    [HttpGet("GetAllWithDetails")]
    public IActionResult GetAllWithDetails()
    {
        return Ok(_orderRepository.GetAll(include: order =>
        order.Include(o=>o.User)
            .Include(o => o.OrderDetails).ThenInclude(od=>od.Product).ThenInclude(p=>p.Category)
            .Include(o => o.OrderDetails).ThenInclude(od=>od.ProductTransaction)
            )
            
       );
    }

    [HttpGet("GetById/{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(_orderRepository.Get(order => order.Id == id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] AddOrderDto addOrderDto)
    {
        if (addOrderDto.ProductTransactions.Count() == 0)
        {
            return BadRequest("Ürün listesi boş olamaz.");
        }
        if (addOrderDto.ProductTransactions.Where(t => t.Quantity == 0).Any())
        {
            return BadRequest("Ürün adedi 0 adet olamaz. Lütfen ürün listesini kontrol ediniz.");
        }
        var checkCounts=addOrderDto.ProductTransactions.Select(t =>
            _productTransactionRepository.GetAll(pt => pt.ProductId == t.ProductId).Sum(transaction=>transaction.Quantity)-t.Quantity
        ).Where(q=>q<0).Any();
        if (checkCounts)
        {
            return BadRequest("Stokta yeteri kadar ürün yok.");
        }
        var addedOrder = _orderRepository.Add(new()
        {
            UserId=addOrderDto.UserId,
            CreatedDate=DateTime.UtcNow
        });
        addOrderDto.ProductTransactions.ToList().ForEach(productTransaction =>
        {
            productTransaction.Quantity = productTransaction.Quantity > 0 ? -1*productTransaction.Quantity : productTransaction.Quantity;
            var addedProductTransaction = _productTransactionRepository.Add(productTransaction);
            _orderDetailRepository.Add(new()
            {
                OrderId= addedOrder.Id,
                ProductId= productTransaction.ProductId,
                ProductTransactionId= addedProductTransaction.Id
            });
        });
        return Ok(addedOrder);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Order order)
    {
        return Ok(_orderRepository.Update(order));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult Delete(Guid id)
    {
        var order = _orderRepository.Get(order => order.Id == id);
        if (order == null) return BadRequest("Order not found");
        return Ok(_orderRepository.Delete(order));
    }
}

