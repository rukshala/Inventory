using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Inventory.Web.Services;

namespace Inventory.Web.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        ProductService _service = new ProductService();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            try
            {
               var products =  await _service.GetProducts();
                return View(products);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = await _service.GetProduct(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductId,Name,Quantity,ReorderLevel,UnitPrice")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.AddProduct(product);
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = await _service.GetProduct(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: Products/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductId,Name,Quantity,ReorderLevel,UnitPrice")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.EditProduct(product);
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
               
                Product product = await _service.GetProduct(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Product product = await _service.GetProduct(id);
                if(product != null)
                {
                    await _service.DeleteProduct(id);

                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

   
    }
}
