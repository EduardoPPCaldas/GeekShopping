using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekShopping.ProductAPI.Data.DTOs;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository;

public class ProductRepository : IProductRepository
{
    private readonly MySQLContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(MySQLContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ProductDTO> Create(ProductDTO dto)
    {
        var product = _mapper.Map<Product>(dto);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<bool> Delete(long id)
    {
        try
        {
            var product = await _context.Products.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            if (product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public async Task<List<ProductDTO>> FindAll()
    {
        var products = await _context.Products.ToListAsync();
        return _mapper.Map<List<ProductDTO>>(products);
    }

    public async Task<ProductDTO> FindById(long id)
    {
        var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> Update(ProductDTO dto)
    {
        var product = _mapper.Map<Product>(dto);
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductDTO>(product);
    }
}
