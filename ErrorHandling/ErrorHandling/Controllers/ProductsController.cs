using Dapper;
using ErrorHandling.Models;
using ErrorHandling.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
//using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErrorHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        SqlConnection con;
        private INLog logger;
        public ProductsController(IConfiguration _configuration, INLog logger)
        {
            con = new SqlConnection(_configuration.GetConnectionString("myDb"));
            this.logger = logger;
        }


        [HttpGet("GetProduct")]
        public ProductsModel GetProduct(int id)
        {
            var dp = new DynamicParameters();
            logger.Information("Get Products called...");
            dp.Add("@id", id);
            var query = "SELECT * from products where id = @id";
            ProductsModel item = con.QueryFirstOrDefault<ProductsModel>(query,dp);
            if (item == null)
            {
                //var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                //{
                //    Content = new StringContent(string.Format("No product with ID = {0}", id)),
                //    ReasonPhrase = "Product ID Not Found"
                //};
                //throw new System.Web.Http.HttpResponseException(resp);
                //logger.Error("Error occured in Get Products...");
                throw new InvalidProductException("Invalid Product Id");
            }
            return item;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
