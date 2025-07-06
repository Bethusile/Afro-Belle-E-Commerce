using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AB.Data;
using AB.Models;
using AB.ViewModels;
using AB.Helpers;

namespace AB.Controllers
{
    public class CartController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly PayPalClient _payPalClient;

        public CartController(ApplicationDbContext context, PayPalClient payPalClient) : base(context)
        {
            _context = context;
            _payPalClient = payPalClient;
        }
        //// Example usage of PayPalClient
        //public IActionResult Checkout()
        //{
        //    var environment = _payPalClient.GetPayPalEnvironment("ATr0Zckn8Ctk-lfpdLgMLoud6qA9K9-fI8M5QwrH9n0yrlGtA7L14qpeJ8PRD7kX5BxyOM8K7bSgtSgT", "ENGi6h51yt7wvjqMlKV4mmRsQJiA6WEwMyg9POLXs4CTXF1pVUMAlABSSuN74Zwv_cx10bL1MGK0P21Q");
        //    // Logic to create orders with PayPal API
        //    return View();
        //}

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            var cartItems = await _context.CartItems.ToListAsync();
            ViewBag.CartTotalQuantity = cartItems.Sum(item => item.Quantity);
            return View(cartItems);
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var cartItem = await _context.CartItems.FirstOrDefaultAsync(m => m.Id == id);
            if (cartItem == null)
                return NotFound();

            return View(cartItem);
        }

        // POST: Cart/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int productId, string size, string color)
        {
            var product = _context.Products.Find(productId);
            if (product == null || product.prodQuantity <= 0)
                return RedirectToAction("Index");

            product.prodQuantity--;

            var cartItem = new CartItem
            {
                ProductId = productId,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                SelectedSize = size,
                SelectedColor = color,
                Quantity = 1,
                Price = product.Price
            };

            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
                return NotFound();

            return View(cartItem);
        }

        // POST: Cart/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Name,SelectedSize,SelectedColor,Quantity,Price")] CartItem cartItem)
        {
            if (id != cartItem.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartItemExists(cartItem.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cartItem);
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var cartItem = await _context.CartItems.FirstOrDefaultAsync(m => m.Id == id);
            if (cartItem == null)
                return NotFound();

            return View(cartItem);
        }

        // POST: Cart/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem != null)
            {
                var product = await _context.Products.FindAsync(cartItem.ProductId);
                if (product != null)
                    product.prodQuantity += cartItem.Quantity;

                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Cart/UpdateQuantity
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int cartItemId, int quantity)
        {
            if (quantity < 1)
                return RedirectToAction(nameof(Index));

            var cartItem = await _context.CartItems.FindAsync(cartItemId);
            if (cartItem != null)
            {
                var product = await _context.Products.FindAsync(cartItem.ProductId);

                if (product != null)
                {
                    int difference = quantity - cartItem.Quantity;

                    if (difference > 0 && product.prodQuantity >= difference)
                    {
                        cartItem.Quantity = quantity;
                        product.prodQuantity -= difference;
                    }
                    else if (difference < 0)
                    {
                        cartItem.Quantity = quantity;
                        product.prodQuantity += Math.Abs(difference);
                    }

                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Cart/Checkout
        public IActionResult Checkout()
        {
            var cartItems = _context.CartItems.ToList();
            var totalAmount = cartItems.Sum(item => item.Price * item.Quantity);

            var checkoutViewModel = new CheckoutViewModel
            {
                CartItems = cartItems,
                TotalAmount = totalAmount,
                ShippingOptions = _context.ShippingOptions.ToList()
            };

            return View(checkoutViewModel);

        }


        //// GET: Cart/OrderConfirmation
        //public async Task<IActionResult> OrderConfirmation(int orderId)
        //{
        //    var order = await _context.Orders.FindAsync(orderId);
        //    if (order == null)
        //        return NotFound();

        //    return View(order);
        //}

        //private async Task<decimal> CalculateDiscountAsync(string discountCode, decimal cartTotal)
        //{
        //    if (discountCode == "SAVE10")
        //        return cartTotal * 0.10m;

        //    return 0m;
        //}


        //// GET: Cart
        //public async Task<IActionResult> Index()
        //{
        //    var cartItems = await _context.CartItems.ToListAsync();
        //    ViewBag.CartTotalQuantity = cartItems.Sum(item => item.Quantity);
        //    return View(cartItems);
        //}

        // GET: Cart/Checkout
        //public IActionResult Checkout()
        //{
        //    var cartItems = _context.CartItems.ToList();
        //    var totalAmount = cartItems.Sum(item => item.Price * item.Quantity);

        //    var checkoutViewModel = new CheckoutViewModel
        //    {
        //        CartItems = cartItems,
        //        TotalAmount = totalAmount,
        //        ShippingOptions = _context.ShippingOptions.ToList()
        //    };

        //    return View(checkoutViewModel);
        //}

        //POST: Cart/CreatePayPalOrder
        [HttpPost]
        public async Task<IActionResult> CreatePayPalOrder(decimal totalAmount)
        {
            try
            {
                var orderId = await _payPalClient.CreateOrderAsync(totalAmount);
                return Ok(new { orderId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // POST: Cart/CapturePayPalOrder
        [HttpPost]
        public async Task<IActionResult> CapturePayPalOrder(string orderId)
        {
            try
            {
                var isCaptured = await _payPalClient.CaptureOrderAsync(orderId);
                if (!isCaptured)
                    return BadRequest(new { error = "Order capture failed." });

                // Save the order to the database
                var cartItems = _context.CartItems.ToList();
                var newOrder = new Order
                {
                    CustomerName = "Anonymous", // Replace with actual customer data
                    Email = "example@example.com", // Replace with actual email
                    Phone = "1234567890", // Replace with actual phone
                    TotalAmount = cartItems.Sum(item => item.Price * item.Quantity),
                    OrderDate = DateTime.UtcNow,
                    Status = "Completed",
                    TransactionId = orderId,
                    PaymentMethod = "PayPal"
                };

                _context.Orders.Add(newOrder);
                _context.CartItems.RemoveRange(cartItems);
                await _context.SaveChangesAsync();

                return Ok(new { success = true, orderId = newOrder.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // GET: Cart/OrderConfirmation
        public async Task<IActionResult> OrderConfirmation(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                return NotFound();

            return View(order);
        }

        private async Task<decimal> CalculateDiscountAsync(string discountCode, decimal cartTotal)
        {
            if (discountCode == "SAVE10")
                return cartTotal * 0.10m;

            return 0m;
        }
        public IActionResult Billing()
        {
            // Calculate the total cart amount
            var cartTotal = _context.CartItems.Sum(ci => ci.Quantity * ci.Price);

            // Fetch available shipping options
            var shippingOptions = _context.ShippingOptions.ToList();

            // Prepare the view model
            var viewModel = new CheckoutViewModel
            {
                TotalAmount = cartTotal, // Initialize with cart total
                ShippingOptions = shippingOptions,
                DiscountCode = string.Empty, // Initialize empty
            };

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult ValidateDiscountCode(string code)
        {
            var discount = _context.DiscountCodes.FirstOrDefault(dc => dc.Code == code && dc.IsActive);
            if (discount != null)
            {
                var cartTotal = _context.CartItems.Sum(ci => ci.Quantity * ci.Price);
                var discountAmount = discount.IsPercentage
                    ? cartTotal * (discount.DiscountAmount / 100)
                    : discount.DiscountAmount;

                return Json(new { success = true, amount = discountAmount });
            }

            return Json(new { success = false });
        }



        private bool CartItemExists(int id) => _context.CartItems.Any(e => e.Id == id);

    }
}