using Microsoft.AspNetCore.Mvc;
using UseCases.Interfaces;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;

        public CategoriesController(IViewCategoriesUseCase viewCategoriesUseCase)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
        }

        public IActionResult Index()
        {
            var categories = viewCategoriesUseCase.Execute();
            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit"; 

            var category = CategoryRepository.GetCategoryById(id.HasValue?id.Value:0);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoryRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "edit";
            return View(category);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";

            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoryRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "add";
            return View(category);
        }

        public IActionResult Delete(int categoryId)
        {
            CategoryRepository.DeleteCategory(categoryId);
            return RedirectToAction(nameof(Index));
        }
    }
}
