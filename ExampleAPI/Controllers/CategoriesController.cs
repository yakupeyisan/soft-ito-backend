using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleAPI.Business.Abstracts;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExampleAPI.Controllers;

[Route("api/[controller]")]
public class CategoriesController : Controller
{
    private ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_categoryService.GetAll());
    }

    [HttpGet("GetAllWithProducts")]
    public IActionResult GetAllWithProducts()
    {
        return Ok(_categoryService.GetAll(include:category=>category.Include(c=>c.Products)));
    }

    [HttpGet("GetById/{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(_categoryService.Get(category=>category.Id==id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] Category category)
    {
        return Ok(_categoryService.Add(category));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Category category)
    {
        return Ok(_categoryService.Update(category));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult Delete(Guid id)
    {
        _categoryService.DeleteById(id);
        return Ok();
    }
}

