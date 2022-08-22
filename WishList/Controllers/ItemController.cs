using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Item> items = _context.Items.ToList();
            return View("Index", items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item obj)
        {
            _context.Items.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var obj = _context.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Items.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
