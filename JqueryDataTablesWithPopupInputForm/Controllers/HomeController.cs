using JqueryDataTablesWithPopupInputForm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JqueryDataTablesWithPopupInputForm.DataAccesslayer;

namespace JqueryDataTablesWithPopupInputForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDbContext _dbContext = new EmployeeDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmployees()
        {
            var employees = _dbContext.Employees.OrderBy(a => a.FirstName).ToList();
            return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            ViewBag.Title = "hello";
            Employee employee = _dbContext.Employees.FirstOrDefault(a => a.EmployeeId == id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Save(Employee employee)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                if (employee.EmployeeId > 0)
                {
                    //For Update
                    _dbContext.Entry(employee).State = EntityState.Modified;
                    
                }
                else
                {
                    //For Create
                    _dbContext.Employees.Add(employee);
                }
                _dbContext.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {

            var v = _dbContext.Employees.FirstOrDefault(a => a.EmployeeId == id);
            if (v != null)
            {
                return View(v);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)
        {
            bool status = false;

            var v = _dbContext.Employees.FirstOrDefault(a => a.EmployeeId == id);
            if (v != null)
            {
                _dbContext.Employees.Remove(v);
                _dbContext.SaveChanges();
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}