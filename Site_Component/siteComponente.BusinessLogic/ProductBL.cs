using siteComponente.BussinessLogic.Core;
using siteComponente.BussinessLogic.Interfaces;
using siteComponente.Domain.Entities.Products;
using siteComponente.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static siteComponente.BussinessLogic.Core.ProductApi;

namespace siteComponente.BussinessLogic
{
     public class ProductBL : ProductApi, IProduct
     {
          public List<Product> GetProductList()
          {
               return AllProducts();
          }
          public Product GetProductById(int id)
          {
               return ProductById(id);
          }
          public ServiceResponse ValidateEditProduct(Product product)
          {
               return ReturnEditProductStatus(product);
          }
          public ServiceResponse ValidateDeleteProduct(Product product)
          {
               return ReturnDeleteProductStatus(product);
          }
          public ServiceResponse ValidateCreateProduct(ProductData product)
          {
               return ReturnCreateProductStatus(product);
          }
     }
}

