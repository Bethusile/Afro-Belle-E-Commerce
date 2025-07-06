using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AB.Data;
using AB.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AB.Controllers
{
    public class BaseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            // Calculate total quantity in the cart
            var cartItems = _context.CartItems.ToList();
            ViewBag.CartTotalQuantity = cartItems.Sum(item => item.Quantity);
        }

        //// GET: Base
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.CartItems.ToListAsync());
        //}

        //// GET: Base/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cartItem = await _context.CartItems
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (cartItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cartItem);
        //}

        //// GET: Base/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Base/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ProductId,Name,SelectedSize,SelectedColor,Quantity,Price")] CartItem cartItem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(cartItem);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cartItem);
        //}

        //// GET: Base/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cartItem = await _context.CartItems.FindAsync(id);
        //    if (cartItem == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(cartItem);
        //}

        //// POST: Base/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Name,SelectedSize,SelectedColor,Quantity,Price")] CartItem cartItem)
        //{
        //    if (id != cartItem.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(cartItem);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CartItemExists(cartItem.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cartItem);
        //}

        //// GET: Base/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cartItem = await _context.CartItems
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (cartItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cartItem);
        //}

        //// POST: Base/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var cartItem = await _context.CartItems.FindAsync(id);
        //    if (cartItem != null)
        //    {
        //        _context.CartItems.Remove(cartItem);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CartItemExists(int id)
        //{
        //    return _context.CartItems.Any(e => e.Id == id);
        //}
    }
}
