using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace SQLClient_Products.Models
{
    public class ProductRepository
    {
        //TODO: Fill in product data access methods....
        // InsertProduct - inserts a product into the database
        public static bool InsertProduct(string name, string description, decimal price, string imageUrl)
        {
            //TODO: INSERT contact in the database
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                con.Open();
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Products (Name, Description, Price, ImageUrl) VALUES (@name, @description, @price, @imageUrl)", con);
                    command.Parameters.Add(new SqlParameter("Name", name));
                    command.Parameters.Add(new SqlParameter("Description", description));
                    command.Parameters.Add(new SqlParameter("Price", price));
                    command.Parameters.Add(new SqlParameter("ImageUrl", imageUrl));
                    command.ExecuteNonQuery();
                    return true;

                }
                catch
                {
                    Console.WriteLine("Could not insert.");
                    Console.ReadKey();
                    return false;
                }
            }
        }

        // DeleteProduct - deletes a product in the database 
        public static bool DeleteProduct(int id)
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                con.Open();
                try
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Products WHERE ProductId = @productId", con);
                    command.Parameters.Add(new SqlParameter("productId", id));
                    command.ExecuteNonQuery();
                    return true;

                }
                catch
                {
                    return false;
                }
            }
        }
        // UpdateProduct - updates a product in the database
        public static bool UpdateProduct(int productId, string name, string description, decimal price, string imageUrl)
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                con.Open();
                try
                {
                    SqlCommand command = new SqlCommand("UPDATE Contacts SET Name = @name, Description = @description, Price = @price, ImageUrl = @imageUrl WHERE ContactId = @contactId", con);
                    command.Parameters.Add(new SqlParameter("productId", productId));
                    command.Parameters.Add(new SqlParameter("name", name));
                    command.Parameters.Add(new SqlParameter("description", description));
                    command.Parameters.Add(new SqlParameter("price", price));
                    command.Parameters.Add(new SqlParameter("imageUrl", imageUrl));
                    command.ExecuteNonQuery();
                    return true;

                }
                catch
                {
                    Console.WriteLine("Could not update.");
                    Console.ReadKey();
                    return false;
                }
            }
        }
        // GetProductById - gets a single product from the database by it's Id
        public static Product GetProductById(int productId)
        {
            List<Product> contacts = new List<Product>();
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Products", con))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0); // Id int
                            string name = reader.GetString(1);  // Name string
                            string description = reader.GetString(2); // Description string
                            decimal price = reader.GetDecimal(3); // Price decimal
                            string imageUrl = reader.GetString(4); // ImageUrl string
                            contacts.Add(new Product()
                            {
                                ProductId = productId,
                                Name = name,
                                Description = description,
                                Price = price,
                                ImageUrl = imageUrl
                            });
                        }
                    }
                    return contacts.Where(x => x.ProductId == productId).First();
                }
                catch
                {
                    return new Product();
                }
            }
        }

        // GetAllProducts - returns all products from the database
        public static List<Product> GetAllProducts()
        {
            //return a list of products to the view.  The view will display a table of all products, with links to edit or delete the product.
            List<Product> products = new List<Product>();
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Products", con))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            int productId = reader.GetInt32(0); // Id int
                            string name = reader.GetString(1);  // Name string
                            string description = reader.GetString(2); // Description string
                            decimal price = reader.GetDecimal(3); // Price decimal
                            string imageUrl = reader.GetString(4); // Url string
                            products.Add(new Product()
                            {
                                ProductId = productId,
                                Name = name,
                                Description = description,
                                Price = price,
                                ImageUrl = imageUrl
                            });
                        }
                    }
                    return products;
                }
                catch
                {
                    return new List<Product>();
                }
            }
        }
    }
}