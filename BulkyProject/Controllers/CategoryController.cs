using AspNetCoreHero.ToastNotification.Abstractions;
using BulkyProject.Data;
using BulkyProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BulkyProject.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDBContext _db;
        private readonly INotyfService _notyf;
        public CategoryController(ApplicationDBContext db , INotyfService notyf) {
            _db = db;     
            _notyf = notyf;
        }
        public IActionResult Index()
        {
            try
            {
                List<Category> objCategory = _db.Category.OrderBy(s => s.Name).ToList();
                return View(objCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                //TempData["success"] = "Category created successfully.";
                _notyf.Success("Category created successfully.");
                //_notyf.Success("Category created successfully.");
                return RedirectToAction("Index");
            }
            return View();            
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            try
            {
                if (Id == null || Id == 0)
                {
                    return NotFound();
                }
                Category? objCategory = _db.Category.FirstOrDefault(x => x.Id == Id);
                if (objCategory == null )
                {
                    NotFound();
                }
                return View(objCategory);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                //TempData["success"] = "Category updated successfully.";
                _notyf.Success("Category updated successfully.");
                return RedirectToAction("Index");
            }
            return View();
            
        }


        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            try
            {
                if (Id == null || Id == 0)
                {
                    return NotFound();
                }
                Category? objCategory = _db.Category.FirstOrDefault(x => x.Id == Id);
                if (objCategory == null)
                {
                    NotFound();
                }
                return View(objCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        public IActionResult Delete(Category obj)
        {
            _db.Category.Remove(obj);
            _db.SaveChanges();
            //TempData["success"] = "Category deleted successfully.";
            _notyf.Success("Category deleted successfully.");
            return RedirectToAction("Index");
        }
    }
}
