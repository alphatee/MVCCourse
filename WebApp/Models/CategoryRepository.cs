﻿namespace WebApp.Models
{
    public static class CategoryRepository
    {
        public static Category? GetCategoryById(int id)
        {
            var category= _categories.FirstOrDefault(c => c.CategoryId == id);
            if(category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,
                };
            }

            return null;
        }

        public static List<Category> GetCategories()
        {
            return _categories;
        }

        public static void AddCategory(Category category)
        {
            if (_categories != null && _categories.Count > 0)
            {
                category.CategoryId = _categories.Max(c => c.CategoryId) + 1;
            }
            else
            {
                category.CategoryId = 1;
            }

            if (_categories == null)
            {
                _categories = new List<Category>();
            }

            _categories.Add(category);
        }

        public static void UpdateCategory(int id, Category category)
        {
            if (id != category.CategoryId) return;

            var existingCategory = _categories.FirstOrDefault(c => c.CategoryId == id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
            }
        }

        public static void DeleteCategory(int id)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}