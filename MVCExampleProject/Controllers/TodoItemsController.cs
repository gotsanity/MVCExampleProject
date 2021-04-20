using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCExampleProject.Data;
using MVCExampleProject.Models;

namespace MVCExampleProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TodoItemsController : Controller
    {
        private readonly TodoContext _context;
        private IUnitOfWork _unitOfWork;
        private ITodoRepository _repo;

        public TodoItemsController(TodoContext context, ITodoRepository repo, IUnitOfWork unitOfWork)
        {
            _context = context;
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        // GET: TodoItems
        public IActionResult Index()
        {
            return View(_repo.GetAllWithComments());
        }

        // GET: TodoItems/Details/5
        public IActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var todoItem = _repo.Get(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        // GET: TodoItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Description,CompletedDate")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                // change here
                _repo.Add(todoItem);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        // GET: TodoItems/Edit/5
        public IActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var todoItem = _repo.Get(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return View(todoItem);
        }

        // POST: TodoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Description,CompletedDate")] TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updatedTodo = _repo.Get(todoItem.Id);

                updatedTodo.Description = todoItem.Description;
                updatedTodo.CompletedDate = todoItem.CompletedDate;

                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        // GET: TodoItems/Delete/5
        public IActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var todoItem = _repo.Get(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        // POST: TodoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var todoItem = _repo.Get(id);
            _repo.Remove(todoItem);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Mark(int id)
        {
            // find item
            var todoItem = _repo.Get(id);

            // update our item
            todoItem.CompletedDate = DateTime.Now;

            // save our changes
            _unitOfWork.Complete();

            // return
            return RedirectToAction(nameof(Index));
        }

        private bool TodoItemExists(int id)
        {
            return _repo.GetAll().Any(e => e.Id == id);
        }
    }
}
