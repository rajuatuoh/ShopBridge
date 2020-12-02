using ShopBridgeAPIApps.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace ShopBridgeAPIApps.Controllers
{
    public class ProductController : ApiController
    {

        public string connectionString = ConfigurationManager.ConnectionStrings["ShopBridgeConn"].ToString();

        [HttpGet]
        public dynamic GetProduct()
        {
            try
            {
                   using (SqlConnection connection = new SqlConnection(connectionString))
                { 
                    DataTable dtDetails = new DataTable();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[getProduct]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dtDetails);
                    connection.Close();
                    return Json(dtDetails);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet]
        public dynamic GetProduct(int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataTable dtDetails = new DataTable();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[getProductById]", connection);
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dtDetails);
                    connection.Close();
                    return Json(dtDetails);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        public dynamic InsertProduct([FromBody] ProductModel product)
        {
            string result = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataTable dtDetails = new DataTable();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[insertProduct]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productName", product.productName);
                    cmd.Parameters.AddWithValue("@productDescription", product.productDescription);
                    cmd.Parameters.AddWithValue("@productPrice", product.productPrice);
                    cmd.Parameters.AddWithValue("@productImg", product.productImg);
                    cmd.Connection = connection;
                    cmd.CommandTimeout = 0;
                    int res = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (res >= 0)
                    {
                        result = "success";
                    }
                    else
                    {
                        result = "fail";
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpDelete]
        public dynamic deleteProduct(int productId)
        {
            string result = string.Empty;
            try
            {
                using (SqlConnection Productconnection = new SqlConnection(connectionString))
                {
                    DataTable dtDetails = new DataTable();
                    Productconnection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[deleteProduct]", Productconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Connection = Productconnection;
                    cmd.CommandTimeout = 0;
                    int res = cmd.ExecuteNonQuery();
                    Productconnection.Close();
                    if (res >= 0)
                    {
                        result = "success";
                    }
                    else
                    {
                        result = "fail";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }
        [HttpPut]
        public dynamic UpdateProduct([FromBody] ProductModel productModel)
        {
            string result = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataTable dtDetails = new DataTable();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[updateProduct]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productId", productModel.productId);
                    cmd.Parameters.AddWithValue("@productName", productModel.productName);
                    cmd.Parameters.AddWithValue("@productDescription", productModel.productDescription);
                    cmd.Parameters.AddWithValue("@productPrice", productModel.productPrice);
                    cmd.Parameters.AddWithValue("@productImg", productModel.productImg);
                    cmd.Connection = connection;
                    cmd.CommandTimeout = 0;
                    int res = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (res >= 0)
                    {
                        result = "success";
                    }
                    else
                    {
                        result = "fail";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }
    }
}
