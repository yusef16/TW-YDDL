using siteComponente.Domain.Entities.Categories;
using siteComponente.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static siteComponente.BussinessLogic.Core.CategoryApi;

namespace siteComponente.BussinessLogic.Interfaces
{
     public interface ICategory
     {
          Category GetCategoryById(int id);
          List<Category> GetCategoryList();
          ServiceResponse ValidateEditCategory(Category category);
          ServiceResponse ValidateDeleteCategory(Category category);
          ServiceResponse ValidateCreateCategory(CategoryData category);

     }
}
