using Dapper;
using Dapperwithproducts.Logger;
using Dapperwithproducts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
//using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dapperwithproducts.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        SqlConnection con;
        private ILog logger;

        public ProductsController(IConfiguration _configuration, ILog logger)
        {
            con = new SqlConnection(_configuration.GetConnectionString("myDb"));
            this.logger = logger;
        }
        // GET: api/<ProductsController>
        [HttpGet("ProductCount")]
        public string ProductCount()
        {
            var version = con.ExecuteScalar<string>("SELECT count(*) from products");
            return version;

        }
        [HttpGet("GetProducts")]
        public ProductsModel GetProducts(int id)
        {
            logger.Information("Get Products method called...");
            var dp = new DynamicParameters();
            dp.Add("@id", id);
            ProductsModel productsData = con.QueryFirstOrDefault<ProductsModel>("SELECT * from products where id = @id",dp);
            if (productsData == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No product with ID = {0}", id)),
                    ReasonPhrase = "Product ID Not Found"
                };
                logger.Error("Error occured in Get Products.");
                throw new System.Web.Http.HttpResponseException(resp);
            }

            return productsData;

        }

        // POST api/<ProductsController>
        [HttpPost("AddProduct")]
        public string AddProduct(string productName, int productPrice)
        {
            try
            {
                var query = "INSERT INTO products(name, price) VALUES(@name, @price)";

                var dp = new DynamicParameters();
                dp.Add("@name", productName, DbType.AnsiString, ParameterDirection.Input, 255);
                dp.Add("@price", productPrice);

                int res = con.Execute(query, dp);
                if (res == 1)
                {
                    return "Product Added...";
                }
                return "Product not Added.";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            

        }
        // POST api/<ProductsController>
        [HttpPost("AddProductFromBody")]
        public string AddProductFromBody([FromBody] ProductsModel productData)
        {
            try
            {
                var query = "INSERT INTO products(name, price) VALUES(@name, @price)";

                var dp = new DynamicParameters();
                dp.Add("@name", productData.Name, DbType.AnsiString, ParameterDirection.Input, 255);
                dp.Add("@price", productData.Price);

                int res = con.Execute(query, dp);
                if (res == 1)
                {
                    return "Product Added...";
                }
                return "Product not Added.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }
        // POST api/<ProductsController>
        [HttpPost("GetProductFromProc")]
        public ProductsModel GetProductFromProc(int id)
        {
            try
            {
                var query = "sp_getProductFromID @id";

                var dp = new DynamicParameters();
                dp.Add("@id", id);

                var  res = con.QueryFirstOrDefault<ProductsModel>(query, dp);
                if (res != null)
                {
                    return res;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
                //return ex.Message;
            }


        }

        // PUT api/<ProductsController>/5
        [HttpPut("UpdateProduct")]
        public string UpdateProduct(int productId, string productName)
        {
            try
            {
                var query = "update products set name = @name where id = @id";

                var dp = new DynamicParameters();
                dp.Add("@name", productName, DbType.AnsiString, ParameterDirection.Input, 255);
                dp.Add("@id", productId);

                int res = con.Execute(query, dp);
                if (res == 1)
                {
                    return "Product Updated...";
                }
                return "Product not Updated.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                var query = "delete from products where id = @id";

                var dp = new DynamicParameters();
                dp.Add("@id", id);

                int res = con.Execute(query, dp);
                if (res == 1)
                {
                    return "Product Deleted...";
                }
                return "Product not Deleted.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
    }
}
