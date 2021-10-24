using ApiRest_Product._2.Application;
using ApiRest_Product._2.Application.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Product._1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductApplication _productApplication;
        private readonly IValidator<ProductDTO> _ProductValidator;

        public ProductController(IProductApplication productApplication, IValidator<ProductDTO> ProductValidator)
        {
            _productApplication = productApplication;
            _ProductValidator = ProductValidator;
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Post([FromBody] ProductDTO product)
        {
            try
            {

                var validationResult = _ProductValidator.Validate(product);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.FirstOrDefault().ToString());
                }

                var result = await _productApplication.AddProduct(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("500 INTERNAL SERVER ERROR");
            }

        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> Update([FromBody] ProductDTO product)
        {
            try
            {

                var validationResult = _ProductValidator.Validate(product);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.FirstOrDefault().ToString());
                }


                var result = await _productApplication.UpdateProduct(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("500 INTERNAL SERVER ERROR");
            }

        }

        [HttpDelete]
        [Route("DeleteProduct/{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            try
            {
                var result = await _productApplication.DeleteProduct(guid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("500 INTERNAL SERVER ERROR");
            }

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _productApplication.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("500 INTERNAL SERVER ERROR");
            }

        }

        [HttpGet]
        [Route("GetProductById/{guid}")]
        public async Task<IActionResult> Get(Guid guid)
        {
            try
            {
                var result = await _productApplication.GetProductById(guid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("500 INTERNAL SERVER ERROR");
            }

        }
    }
}
