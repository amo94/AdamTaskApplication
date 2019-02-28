using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdamTaskApplication.Models;
using AdamTaskApplication.Data.Repositries;
using AdamTaskApplication.Data.Interfaces;
using AdamTaskApplication.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using AdamTaskApplication.Data;

namespace AdamTaskApplication.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmployee _Employee ;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFiles _File;
        
        public HomeController(IEmployee Employee , IFiles files ,  IHostingEnvironment hostingEnvironment)
        {
            this._Employee = Employee;
            this._hostingEnvironment = hostingEnvironment;
            this._File = files;
        }
        
        public IActionResult Index()
        {
            var Employees = _Employee.GetAll();
            return View(Employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee , IList<IFormFile> EmployeeFiles)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            _Employee.Create(employee);
            
            // Write files to the hosting
            if (EmployeeFiles.Count != 0)
            {
                var UploadsDirectory = Path.Combine(_hostingEnvironment.ContentRootPath, "EmployeeFiles");
               
                foreach (var item in EmployeeFiles)
                {
                    Files newFile;

                    if (item.Length > 0 )
                    {
                        var FilePath = Path.Combine(UploadsDirectory, item.FileName.Replace(" ","").Replace("-","_"));
                        using (var FileWritter = new FileStream (FilePath, FileMode.Create))
                        {
                            await item.CopyToAsync(FileWritter);
                            newFile = new Files();
                            // Note : the business logic doing in the files repository not here and Here we just pass the values to the repository 
                            newFile.FileName = item.FileName;
                            newFile.Description = FilePath;
                            newFile.FileExtension = Path.GetExtension(item.FileName);
                            newFile.EmployeeID = employee.Id;
                            newFile.OwnerType = OwnerTypes.Empolyee;
                            _File.Create(newFile);
                        }
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Employees/Edit/5
        public IActionResult  Edit(int id)
        {
            var employee =  _Employee.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult  Edit(long id, [Bind("FirstName,LastName,Gender,JobTitle,Country,CityID,BirthDate,Address,Nationalty1,Nationalty2,Notes,Id")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _Employee.Update(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

             

        public IActionResult Delete(int id)
        {
            var Employee = _Employee.GetById(id);
            _Employee.Delete(Employee);

            var allemployeefiles = _File.Find(x => x.EmployeeID == id);
            foreach (var item in allemployeefiles)
            {
                _File.Delete(item);
            }
            return RedirectToAction(nameof(Index));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
