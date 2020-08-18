using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Inventory.Web.Services
{
    public class ProductService
    {
        private InventoryAppContext db = new InventoryAppContext();

        /// <summary>
        /// Get all available Products
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetProducts()
        {
            try
            {
                return await db.Products.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get exisiting product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Product> GetProduct(int? productId)
        {
            try
            {
                if (!productId.HasValue)
                {
                    return null;
                }
                else
                {
                    Product product = await db.Products.FindAsync(productId);

                    return product;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Add Product to DB
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task AddProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    db.Products.Add(product);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Delee an Existing prodcuct
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task DeleteProduct(int productId)
        {
            try
            {
                Product product = await db.Products.FindAsync(productId);
                db.Products.Remove(product);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Edit an exisiting product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task EditProduct(Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}