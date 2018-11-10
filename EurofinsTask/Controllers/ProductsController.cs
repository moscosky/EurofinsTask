using EurofinsTask.Models;
using EurofinsTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EurofinsTask.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductService _productService;

        public ProductsController()
        {
            _productService = new ProductService();
        }
        // GET api/Products
        public IEnumerable<Product> Get()
        {
            return _productService.GetProducts();
        }

        // GET api/Products/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_productService.GetProduct(id));
        }

        // POST api/Products
        public IHttpActionResult Post([FromBody]Product product)
        {
            try
            {
                _productService.AddProduct(product);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/Products/5
        public IHttpActionResult Put([FromBody]Product product)
        {
            try
            {
                _productService.UpdateProduct(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/Products/5
        public IHttpActionResult Delete(int id)
        {
            if(_productService.RemoveProduct(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
