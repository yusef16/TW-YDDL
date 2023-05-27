using siteComponente.BussinessLogic.Core;
using siteComponente.BussinessLogic.Interfaces;
using siteComponente.Domain.Entities.Categories;
using siteComponente.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siteComponente.BussinessLogic
{
     public class CategoryBL : CategoryApi, ICategory
     {
          public List<Category> GetCategoryList()
          {
               return AllCategories();
          }
          public Category GetCategoryById(int id)
          {
               return CategoryById(id);
          }
          public ServiceResponse ValidateEditCategory(Category category)
          {
               return ReturnEditCategoryStatus(category);
          }
          public ServiceResponse ValidateDeleteCategory(Category category)
          {
               return ReturnDeleteCategoryStatus(category);
          }
          public ServiceResponse ValidateCreateCategory(CategoryData category)
          {
               return ReturnCreateCategoryStatus(category);
          }
     }
}