using siteComponente.BussinessLogic.DBModel;
using siteComponente.Domain.Entities.Products;
using siteComponente.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siteComponente.BussinessLogic.Core
{
     public class ProductApi
     {

          public struct ProductData
          {
               public string Name { get; set; }
               public int CategoryID { get; set; }
               public decimal Price { get; set; }
               public int Amount { get; set; }
               public string Thumbnail { get; set; }
          }

          public List<Product> AllProducts()
          {
               List<Product> products = null;
               using (var db = new ProductsContext())
               {
                    products = db.Products.OrderByDescending(p => p.Name).ToList();
               }

               return products;
          }

          public Product ProductById(int id)
          {
               using (var db = new ProductsContext())
               {
                    var currentProduct = db.Products.FirstOrDefault(x => x.Id == id);
                    if (currentProduct == null)
                    {
                         return null;
                    }
                    return currentProduct;
               }
          }
          public List<Product> CategoryProducts(int id)
          {
               List<Product> products = null;
               using (var db = new ProductsContext())
               {
                    products = db.Products.Where(p => p.Id == id).ToList();

               }

               return products;
          }
          public ServiceResponse ReturnEditProductStatus(Product data)
          {
               var response = new ServiceResponse();
               using (var db = new ProductsContext())
               {
                    try
                    {
                         var existingProduct = db.Products.FirstOrDefault(x => x.Id == data.Id);
                         if (existingProduct == null)
                         {
                              response.StatusMessage = "Product not found";
                              response.Status = false;

                              return response;
                         }


                         var duplicateProduct = db.Products.FirstOrDefault(u => (u.Name == data.Name) && u.Id != data.Id);
                         if (duplicateProduct != null)
                         {
                              response.StatusMessage = "Username or email already exists for another user";
                              response.Status = false;
                              return response;
                         }
                         else
                         {
                              existingProduct.Name = data.Name;
                              existingProduct.CategoryID = data.CategoryID;
                              existingProduct.Price = data.Price;
                              existingProduct.Amount = data.Amount;
                              existingProduct.Thumbnail = data.Thumbnail;

                              db.SaveChanges();


                              response.StatusMessage = "Product updated successfully";
                              response.Status = true;
                              return response;
                         }


                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while updating the Product";
                         response.Status = false;

                    }
                    return response;

               }
          }
          public ServiceResponse ReturnCreateProductStatus(ProductData data)
          {
               var response = new ServiceResponse();
               using (var db = new ProductsContext())
               {
                    try
                    {
                         //     // Check if the user already exists in the database
                         var existingProduct = db.Products.FirstOrDefault(u => u.Name == data.Name);
                         if (existingProduct != null)
                         {
                              response.StatusMessage = "Product with this name already exists";
                              response.Status = false;
                              return response;
                         }

                         var product = new Product
                         {
                              Name = data.Name,
                              CategoryID = data.CategoryID,
                              Price = data.Price,
                              Amount = data.Amount,
                              Thumbnail = data.Thumbnail,
                         };
                         using (var db2 = new ProductsContext())
                         {
                              db2.Products.Add(product);
                              db2.SaveChanges();
                         }

                         response.StatusMessage = "Product added successfully";
                         response.Status = true;
                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while adding the product";
                         response.Status = false;
                         //response.Exception = ex;
                    }
                    return response;
               }
          }
          public ServiceResponse ReturnDeleteProductStatus(Product deleteProduct)
          {
               var response = new ServiceResponse();
               using (var db = new ProductsContext())
               {
                    try
                    {
                         var existingProduct = db.Products.FirstOrDefault(u => u.Id == deleteProduct.Id);
                         if (existingProduct == null)
                         {
                              response.StatusMessage = "Product not found";
                              response.Status = false;
                              return response;
                         }

                         db.Products.Remove(existingProduct);

                         response.StatusMessage = "Product deleted successfully";
                         response.Status = true;

                         db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while deleting the Product";
                         response.Status = false;
                    }
                    return response;
               }
          }
     }
}

