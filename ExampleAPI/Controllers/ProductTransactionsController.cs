using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExampleAPI.Controllers;

[Route("api/[controller]")]
public class ProductTransactionsController : Controller
{
    private IProductTransactionRepository _productTransactionRepository;

    public ProductTransactionsController(IProductTransactionRepository productTransactionRepository)
    {
        _productTransactionRepository = productTransactionRepository;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_productTransactionRepository.GetAll());
    }
    [HttpGet("GetAllWithProduct")]
    public IActionResult GetAllWithProduct()
    {
        return Ok(_productTransactionRepository.GetAll(include:productTransaction=> productTransaction.Include(p=>p.Product)));
    }

    [HttpGet("GetById/{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(_productTransactionRepository.Get(productTransaction=>productTransaction.Id==id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] ProductTransaction productTransaction)
    {
        return Ok(_productTransactionRepository.Add(productTransaction));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] ProductTransaction productTransaction)
    {
        return Ok(_productTransactionRepository.Update(productTransaction));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult Delete(Guid id)
    {
        var productTransaction = _productTransactionRepository.Get(productTransaction => productTransaction.Id == id);
        if (productTransaction == null) return BadRequest("ProductTransaction not found");
        return Ok(_productTransactionRepository.Delete(productTransaction));
    }
}

