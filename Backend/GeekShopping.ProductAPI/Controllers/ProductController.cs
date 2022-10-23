using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekShopping.ProductAPI.Data.DTOs;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> FindById([FromRoute] long id)
    {
        var product = await _repository.FindById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDTO>>> FindAll()
    {
        var products = await _repository.FindAll();
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> Create(ProductDTO dto)
    {
        if(dto == null) return BadRequest();
        var product = await _repository.Create(dto);
        return Created("", product);
    }

    [HttpPut]
    public async Task<ActionResult<ProductDTO>> Update(ProductDTO dto)
    {
        if(dto == null) return BadRequest();
        var product = await _repository.Update(dto);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var status = await _repository.Delete(id);
        if (!status) return BadRequest();
        return NoContent();
    }
}
