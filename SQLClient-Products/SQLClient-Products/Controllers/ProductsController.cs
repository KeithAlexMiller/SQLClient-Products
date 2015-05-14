using SQLClient_Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLClient_Products.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            //return a list of products to the view.  The view will display a table of all products, with links to edit or delete the product.
            return View(ProductRepository.GetAllProducts());
        }

        //TODO: Create Create actions.  
        //The GET action will take no arguments and pass an empty Product object to the View and display the Create form to the user.  
        //The POST action will accept a Product object as an argument, handle the uploading of an image file, then add it to the database.

        //TODO: Create Edit actions.  
        //The GET action will accept an integer Id as an arguement.  The action will retrieve the product from the database, and pass it to the view to display the Edit form to the user, with the field values populated from the database.
        //The POST action will accept an integer Id and a product object as arguements.  The action will then upload a new file if one was selected, then update the record in the database.

        //TODO: Create Delete action
        //The GET action will accept an integer Id as an arguement and retrieve the product from the database.  The product object will be passed to the view to display to the user a confirmation screen with a button to confirm that links to the DeleteConfirmation action.

        //TODO: Create DeleteConfirmation action
        //The GET action will accept an integer Id as an arguement and delete the product from the database.  After the deletion is complete, redirect the user to the Index (listing) action.
        public ActionResult List()
        {
            //show all the contacts
            return View(ProductRepository.GetAllProducts());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Error = string.Empty;
            //return a blank create form
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Models.Product product)
        {
            //add the new contact to the database
            if (ProductRepository.InsertProduct(product.Name, product.Description, product.Price, product.ImageUrl))
            {
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Error = "Failed to create new contact.  Set a breakpoint and figure out why!";
                return View(product);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //get the contact from the database and pass it to the view to populate the form.
            Product product = ProductRepository.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            //update the contacti in the database
            if (ProductRepository.UpdateProduct(id, product.Name, product.Description, product.Price, product.ImageUrl))
            {
                return RedirectToAction("List");
            }
            else
            {
                //failed
                ViewBag.Error = "Failed to update contact.  Set a breakpoint and figure out why!";
                return View(product);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            //delete thecontact from the database.
            if (ProductRepository.DeleteProduct(id))
            {
                return RedirectToAction("List"); //go back to the list
            }
            else
            {
                //failed
                ViewBag.Error = "Failed to delete contact.  Set a breakpoint and figure out why!";
                return RedirectToAction("List");
            }
        }

    }
}