using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExampleAPI.Controllers;

[Route("api/[controller]")]
public class CategoriesController : Controller
{
    private ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_categoryRepository.GetAll());
    }

    [HttpGet("GetAllWithProducts")]
    public IActionResult GetAllWithProducts()
    {
        return Ok(_categoryRepository.GetAll(include:category=>category.Include(c=>c.Products)));
    }

    [HttpGet("GetById/{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(_categoryRepository.Get(category=>category.Id==id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] Category category)
    {
        return Ok(_categoryRepository.Add(category));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Category category)
    {
        return Ok(_categoryRepository.Update(category));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult Delete(Guid id)
    {
        var category = _categoryRepository.Get(category => category.Id == id);
        if (category == null) return BadRequest("Category not found");
        return Ok(_categoryRepository.Delete(category));
    }
}

