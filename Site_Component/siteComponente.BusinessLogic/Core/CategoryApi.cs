using siteComponente.BussinessLogic.DBModel;
using siteComponente.Domain.Entities.Categories;
using siteComponente.Domain.Entities.Products;
using siteComponente.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace siteComponente.BussinessLogic.Core
{
     public class CategoryApi
     {
          public struct CategoryData
          {
               public string Name { get; set; }
               public string Thumbnail { get; set; }
          }

          public List<Category> AllCategories()
          {
               List<Category> categories = null;
               using (var db = new CategoriesContext())
               {
                    categories = db.Categories.OrderByDescending(p => p.Name).ToList();
               }

               return categories;
          }

          public Category CategoryById(int id)
          {
               using (var db = new CategoriesContext())
               {
                    var currentCategory = db.Categories.FirstOrDefault(x => x.Id == id);
                    if (currentCategory == null)
                    {
                         return null;
                    }
                    return currentCategory;
               }
          }

          public ServiceResponse ReturnEditCategoryStatus(Category data)
          {
               var response = new ServiceResponse();
               using (var db = new CategoriesContext())
               {
                    try
                    {
                         var existingCategory = db.Categories.FirstOrDefault(x => x.Id == data.Id);
                         if (existingCategory == null)
                         {
                              response.StatusMessage = "Category not found";
                              response.Status = false;

                              return response;
                         }


                         var duplicateCategory = db.Categories.FirstOrDefault(u => (u.Name == data.Name) && u.Id != data.Id);
                         if (duplicateCategory != null)
                         {
                              response.StatusMessage = "Username or email already exists for another user";
                              response.Status = false;
                              return response;
                         }
                         else
                         {
                              existingCategory.Name = data.Name;
                              existingCategory.Thumbnail = data.Thumbnail;

                              db.SaveChanges();


                              response.StatusMessage = "Category updated successfully";
                              response.Status = true;
                              return response;
                         }


                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while updating the Category";
                         response.Status = false;

                    }
                    return response;

               }
          }
          public ServiceResponse ReturnCreateCategoryStatus(CategoryData data)
          {
               var response = new ServiceResponse();
               using (var db = new CategoriesContext())
               {
                    try
                    {
 
                         var existingCategory = db.Categories.FirstOrDefault(u => u.Name == data.Name);
                         if (existingCategory != null)
                         {
                              response.StatusMessage = "Category with this name already exists";
                              response.Status = false;
                              return response;
                         }

                         var category = new Category
                         {
                              Name = data.Name,
                              Thumbnail = data.Thumbnail,
                         };
                         using (var db2 = new CategoriesContext())
                         {
                              db2.Categories.Add(category);
                              db2.SaveChanges();
                         }

                         response.StatusMessage = "Category added successfully";
                         response.Status = true;
                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while adding the category";
                         response.Status = false;
                         //response.Exception = ex;
                    }
                    return response;
               }
          }
          public ServiceResponse ReturnDeleteCategoryStatus(Category deleteCategory)
          {
               var response = new ServiceResponse();
               using (var db = new CategoriesContext())
               {
                    try
                    {
                         var existingCategory = db.Categories.FirstOrDefault(u => u.Id == deleteCategory.Id);
                         if (existingCategory == null)
                         {
                              response.StatusMessage = "Category not found";
                              response.Status = false;
                              return response;
                         }

                         db.Categories.Remove(existingCategory);

                         response.StatusMessage = "Category deleted successfully";
                         response.Status = true;

                         db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while deleting the Category";
                         response.Status = false;
                    }
                    return response;
               }
          }
     }
}
