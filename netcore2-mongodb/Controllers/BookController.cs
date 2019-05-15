using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netcore2.Repository.Document;
using netcore2.Repository.Repository;

namespace netcore2_mongodb.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository _BookRepository { set; get; }

        public BookController(IBookRepository BookRepository) {

            _BookRepository = BookRepository;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
            var getAll = await _BookRepository.ListAsync();
            return View(getAll);
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var entity = await _BookRepository.FindAsync(id);
            return View(entity);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book data)
        {
            try
            {
                // TODO: Add insert logic here
                await _BookRepository.AddAsync(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var entity = await _BookRepository.FindAsync(id);
            return View(entity);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Book data)
        {
            try
            {
                // TODO: Add update logic here
                await _BookRepository.UpdateAsync(data, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var entity = await _BookRepository.FindAsync(id);
            return View(entity);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, IFormCollection data)
        {
            try
            {
                // TODO: Add delete logic here
                await _BookRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}