using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Dapper; // for using dapper  
using System.Configuration; // for using Configuration Setting.  
using System.Data.SqlClient;
using DapperProdutsApi.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
//Using Connection string For database operations.  


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperProdutsApi.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        SqlConnection con;
        public ProductsController(IConfiguration _configuration)
        {
            con = new SqlConnection(_configuration.GetConnectionString("MyConn"));
        }
        // GET: api/<ProductsController>
        [HttpGet("/getProducts")]
        public IEnumerable<ProductsModel> Get()
        {
            string query = "select * from Products";
            var result = con.Query<ProductsModel>(query);
            return result;
        }

        // GET api/<ProductsController>/5
        [HttpGet("/getScalar")]
        public string GetScalar()
        {
            var version = con.ExecuteScalar<string>("SELECT @@VERSION");
            return version;
        }
        // POST api/<ProductsController>
        [HttpPost("/insertProductForm")]
        public int InsertProductsForm([FromBody] ProductsModel productData)
        {
            //var query = "INSERT INTO products(name, price) VALUES(@name, @price)";

            //var dp = new DynamicParameters();
            //dp.Add("@name", name, DbType.AnsiString, ParameterDirection.Input, 255);
            //dp.Add("@price", price);
            
            int res = 1; // con.Execute(query, dp);

            if (res > 0)
            {
                return 1;
            }
            return 0;
        }
        // POST api/<ProductsController>
        [HttpPost("/insertProduct")]
        public int InsertProducts( string name, string price)
        {
            var query = "INSERT INTO products(name, price) VALUES(@name, @price)";

            var dp = new DynamicParameters();
            dp.Add("@name", name, DbType.AnsiString, ParameterDirection.Input, 255);
            dp.Add("@price", price);

            int res = con.Execute(query, dp);

            if (res > 0)
            {
                return 1; 
            }
            return 0;
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
