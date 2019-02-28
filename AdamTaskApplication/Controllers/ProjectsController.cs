using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdamTaskApplication.Data;
using AdamTaskApplication.Data.Models;
using AdamTaskApplication.Data.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace AdamTaskApplication.Controllers
{
    public class ProjectsController : Controller
    {

        private readonly IProjects _Projects;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFiles _File;

        public ProjectsController(IFiles File , IProjects Projects, IHostingEnvironment hostingEnvironment  )
        {
            this._Projects = Projects;
            this._File = File;
            this._hostingEnvironment = hostingEnvironment;
        }

        // GET: Projects
        public IActionResult Index()
        {
               var Projects = _Projects.GetAll();
               return View(Projects);
        }

      
        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] Projects projects)
        {
            if (ModelState.IsValid)
            {
              
                return RedirectToAction(nameof(Index));
            }
            return View(projects);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = "dsffsds";
            if (projects == null)
            {
                return NotFound();
            }
            return View(projects);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Name,Id")] Projects projects)
        {
            if (id != projects.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectsExists(projects.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projects);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = "";  


            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectsExists(long id)
        {
            return true;
        }
    }
}
