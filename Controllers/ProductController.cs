using Microsoft.AspNetCore.Mvc;
using CRUD.Repo;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class ProductController : Controller
    {
        private static readonly ProductRepository _repository = new();

        public IActionResult Index() => View(_repository.GetAll());

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid) 
            {
                _repository.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _repository.GetById(id);
            return product != null ? View(product) : NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(product);
              
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult List()
        {
          var products = _repository.GetAll();
    return Ok(products);
}

    }
}
