using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoesShop.Models;

namespace ShoesShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly CatalogContext _context;

        public CatalogController(CatalogContext context)
        {
            _context = context;
        }
        /// <summary>
        /// This method is used for transfering data from client to server when the "Catalog" menu is selected.
        /// </summary>
        /// <returns></returns>
        // GET: Catalog
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catalog.ToListAsync());
        }
        /// <summary>
        /// This method is used for transfering data from client to server when the "Catalog/Details" menu is selected.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Catalog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalog
                .FirstOrDefaultAsync(m => m.ID == id);
            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }
        /// <summary>
        /// This method is used for transfering data from client to server when the "Catalog/Create" menu is selected.
        /// </summary>
        /// <returns></returns>
        // GET: Catalog/Create
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// This method is used for transfering data from client to server when the "Catalog/Create" menu is selected.
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        // POST: Catalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Gender,Size,Type,Colour,Quantity,Price")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalog);
        }
        /// <summary>
        /// This method is used for transfering data from client to server when the "Catalog/Edit" menu is selected.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Catalog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalog.FindAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }
            return View(catalog);
        }
        /// <summary>
        /// This method is used for transfering data from client to server when the "Catalog/Edit" menu is selected.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="catalog"></param>
        /// <returns></returns>
        // POST: Catalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Gender,Size,Type,Colour,Quantity,Price")] Catalog catalog)
        {
            if (id != catalog.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogExists(catalog.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catalog);
        }
        /// <summary>
        /// This method is used for transfering data from client to server when the "Catalog/Delete" menu is selected.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Catalog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalog
                .FirstOrDefaultAsync(m => m.ID == id);
            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }
        /// <summary>
        /// This method is used for transfering data from client to server when the "Catalog/Delete" menu is selected.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Catalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalog = await _context.Catalog.FindAsync(id);
            _context.Catalog.Remove(catalog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogExists(int id)
        {
            return _context.Catalog.Any(e => e.ID == id);
        }
    }
}
