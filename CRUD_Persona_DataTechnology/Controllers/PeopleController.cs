using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Persona_DataTechnology.Models;
using CRUD_Persona_DataTechnology.Models.Entities;
using CRUD_Persona_DataTechnology.Bll;
using CRUD_Persona_DataTechnology.Models.Dal;

namespace CRUD_Persona_DataTechnology.Controllers
{
    public class PeopleController : Controller
    {
        private readonly DataContext _context;
        private readonly PersonBLL bll;
        public PeopleController(DataContext context)
        {
            _context = context;
            bll = new PersonBLL(_context);
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            var list = await bll.GetPeopleAsync();
            return View(list);
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.TypeDocument)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public async Task<IActionResult> Create()
        {
            var bll = new TypeDocumentBLL(_context);
            var list = await bll.GetTypeDocumentsAsync();
            ViewData["TypeDocumentId"] = new SelectList(list, "TypeDocumentId", "Name");
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,Name,Email,TypeDocumentId,Document,Birthday")] Person person)
        {
            if (ModelState.IsValid)
            {
                bll.CreatePersonAsync(person);
                return RedirectToAction(nameof(Index));
            }
            var bllTd = new TypeDocumentBLL(_context);
            var list = await bllTd.GetTypeDocumentsAsync();
            ViewData["TypeDocumentId"] = new SelectList(list, "TypeDocumentId", "Name", person.TypeDocumentId);
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var person = await new PersonDAL(_context).FindPersonByIdAsync((int)id);
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var bllTd = new TypeDocumentBLL(_context);
            var list = await bllTd.GetTypeDocumentsAsync();
            ViewData["TypeDocumentId"] = new SelectList(list, "TypeDocumentId", "Name", person.TypeDocumentId);
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,Name,Email,TypeDocumentId,Document,Birthday")] Person person)
        {
            if (id != person.PersonId)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                var resp = bll.UpdatePersonAsync(person);
                return RedirectToAction(nameof(Index));
            }
            var bllTd = new TypeDocumentBLL(_context);
            var list = await bllTd.GetTypeDocumentsAsync();
            ViewData["TypeDocumentId"] = new SelectList(list, "TypeDocumentId", "Name", person.TypeDocumentId);
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var person = await bll.FindPersonByIdAsync((int)id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bll.DeletePersonAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
