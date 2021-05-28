using AutoMapper;
using DepartmentalStoreAppAPI.Application.RepositoryInterface;
using DepartmentalStoreAppAPI.Domain;
using DepartmentalStoreAppAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        public ProductController(IProductRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }
        [HttpGet]
        public async Task<ActionResult<ProductModel[]>> Get(bool includeInvantory = true)    
        {
            try
            {
                var result = await _repository.GetAllProductAsync(includeInvantory);
                return _mapper.Map<ProductModel[]>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpGet("{productname}")]
        public async Task<ActionResult<ProductModel>> Get(string productname, bool includeStaffRole = true)       // to use any specific type of return value
        {
            try
            {
                var result = await _repository.GetAProductAsync(productname, includeStaffRole);

                return _mapper.Map<ProductModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductModel>> GetStaffById(int id, bool includeStaffRole = true)
        {
            try
            {
                var result = await _repository.GetAProductAsyncByID(id, includeStaffRole);

                return _mapper.Map<ProductModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpPost]
        public async Task<ActionResult<ProductModel>> Post(Product product)
        {
            try
            {
                _repository.Add(product);
                if (await _repository.SaveChangesAsync())
                {
                    var url = _linkGenerator.GetPathByAction("Post", "Product",
                          new { product.ProductId }
                          );

                    return Created(url, _mapper.Map<ProductModel>(product));
                }
                else
                {
                    return BadRequest("Failed to add new Product");
                }

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Failed to get Product");
            }
        }
        [HttpPut("{productId}")]
        public async Task<ActionResult<ProductModel>> Put(int productId, ProductModel model)
        {
            try
            {
                var product = await _repository.GetAProductAsyncByID(productId, true);
                if (product == null) return NotFound("Couldn't find the Product");


                _mapper.Map(model, product , opt => opt.BeforeMap((s,d)=> s.ProductId = d.ProductId));
                //product = model;
                //product.ProductId = productId;
                _repository.Update(product);

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<ProductModel>(model);
                }
                else
                {
                    return BadRequest("Failed to update database.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get Product");
            }
            
        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                var product = await _repository.GetAProductAsyncByID(productId,true);
                if (product == null) return NotFound("Failed to find the staff to delete");
                _repository.Delete(product);



                if (await _repository.SaveChangesAsync())
                {
                    return Ok("Product Deleted Successfully");
                }
                else
                {
                    return BadRequest("Failed to delete Product");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get Product");
            }
        }
    }
}
