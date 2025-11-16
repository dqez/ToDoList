using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoList.Core;
using TodoList.UseCases;
using TodoList.Web.Models;

namespace TodoList.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITodoListRepository _repository;

        public HomeController(ILogger<HomeController> logger, ITodoListRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var list = _repository.GetAllTodoItems().Select(ti => new Item()
            {
                Id = ti.Id,
                Title = ti.Title,
                Description = ti.Description,
                IsCompleted = ti.IsCompleted,
                CreatedDate = ti.CreatedDate,
                UpdatedDate = ti.UpdatedDate
            });
            
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _repository.AddTodoItem(new TodoItem()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    IsCompleted = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _repository.RemoveTodoItem(id);
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
