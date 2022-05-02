using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemoEF.Models;
using WebApplicationDemoEF.StudentDBContext;

namespace WebApplicationDemoEF.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;
        public StudentController(StudentDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }
        public IActionResult Create()

        {
            Student student = new Student();
            return View(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {

            Student student = _context.Students.FirstOrDefault(x => x.Id == id);
            if(student !=null)
            
          return View(student);
            else
            {
                ViewBag.msg = "There is no Record with this ID";
           return View();
            }
    }

    [HttpPost]
    public IActionResult Edit(int id, Student student)
        {
            Student obj = _context.Students.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                foreach (Student temp in _context.Students)
                {
                    if (temp.Id == obj.Id)
                    {
                        temp.Batch = student.Batch;
                        temp.Marks = student.Marks;
                    }
                }
                _context.SaveChanges();
            }
        return RedirectToAction("Index");
    }

        public IActionResult Delete(int id)
        {

            Student student = _context.Students.FirstOrDefault(x => x.Id == id);
            if (student != null)

                return View(student);
            else
            {
                ViewBag.msg = "There is no Record with this ID";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id, Student student)
        {
            Student obj = _context.Students.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                _context.Students.Remove(obj);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {

            Student student = _context.Students.FirstOrDefault(x => x.Id == id);
            if (student != null)

                return View(student);
            else
            {
                ViewBag.msg = "There is no Record with this ID";
                return View();
            }
        }
    }
}
