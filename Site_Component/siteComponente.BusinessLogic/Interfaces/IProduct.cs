using siteComponente.Domain.Entities.Products;
using siteComponente.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static siteComponente.BussinessLogic.Core.ProductApi;

namespace siteComponente.BussinessLogic.Interfaces
{
     public interface IProduct
     {
          Product GetProductById(int id);
          List<Product> GetProductList();
          ServiceResponse ValidateEditProduct(Product product);
          ServiceResponse ValidateDeleteProduct(Product product);
          ServiceResponse ValidateCreateProduct(ProductData product);
     }
}

