using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.IO;
namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            using (ProductdbEntities2 db = new ProductdbEntities2())
            {
                List<tblProduct> ProductList = (from data in db.tblProducts select data).ToList();
                return View(ProductList);
            }
          
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View(new tblProduct());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(tblProduct product ,HttpPostedFileBase postedFileBase)
        {
            try
            {
                using (ProductdbEntities2 db = new ProductdbEntities2())
                {
                    db.tblProducts.Add(product);
                    db.SaveChanges();
                }
                   
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {

            using (ProductdbEntities2 db = new ProductdbEntities2())
            {
                tblProduct product = db.tblProducts.Find(id);

                return View(product);
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(tblProduct product, HttpPostedFileBase postedFileBase)
        {
            try
            {
                using (ProductdbEntities2 db = new ProductdbEntities2())
                {
                    tblProduct tbl = db.tblProducts.Find(product.Product_Id);
                    tbl.Product_name = product.Product_name;
                    tbl.Product_price = product.Product_price;
                    tbl.Product_qty = product.Product_qty;
                    tbl.CategoryId = product.CategoryId;
                    tbl.CategoryName = product.CategoryName;
                    db.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (ProductdbEntities2 db = new ProductdbEntities2())
            {
                db.tblProducts.Remove(db.tblProducts.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
