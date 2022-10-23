using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekShopping.ProductAPI.Data.DTOs;

namespace GeekShopping.ProductAPI.Repository;

public interface IProductRepository
{
    Task<List<ProductDTO>> FindAll();
    Task<ProductDTO> FindById(long id);
    Task<ProductDTO> Create(ProductDTO dto);
    Task<ProductDTO> Update(ProductDTO dto);
    Task<bool> Delete(long id);
}
