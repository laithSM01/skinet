using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _prodcutRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> prodcut, IGenericRepository<ProductBrand> brand,
            IGenericRepository<ProductType> type, IMapper mapper)
        {
            _prodcutRepo = prodcut;
            _productBrandRepo = brand;
            _productTypeRepo = type;
            _mapper = mapper;
        }

            /*
             * getAllAsync() returns list , we don't know what type
             * this is why we will know by creating a specification Class
             */

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var specification = new ProductswithTypesAndBrandsSpecification();
            var products = await _prodcutRepo.ListAsync(specification);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
            //return products.Select(product => new ProductToReturnDto
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    PictureUrl = product.PictureUrl,
            //    Price = product.Price,
            //    ProductBrand = product?.ProductBrand?.Name,
            //    ProductType = product?.ProductType?.Name
            //}).ToList();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(statusCode:200)]
        [ProducesResponseType(typeof(ApiResponse), statusCode:404)]//this is to match our new class to swagger document
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var specification = new ProductswithTypesAndBrandsSpecification(id);
            var product = await _prodcutRepo.GetEntityWithSpec(specification);
            if(product == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getBrands()
        {
            var brands = await _productBrandRepo.GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getTypes()
        {
            var types = await _productTypeRepo.GetAllAsync();
            return Ok(types);
        }
    }
}
