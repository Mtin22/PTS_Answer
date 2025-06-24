using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MVC_App.Models;

namespace MVC_App.Controllers;


public class StudentController : Controller
{
    private Context _context;

    public StudentController(Context context) {
        _context = context;
    }


    public async Task<IActionResult> Students()
    {
        var students = await _context.Students.ToListAsync();
        return View(students);
    }

    public IActionResult Add_Student()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Students");
        }
        return View("Add_Student", student);
    }

    public async Task<IActionResult> Edit_Student(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit_Student(int id, Student student)
    {
        if (id != student.Id) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Students");
        }
        return View(student);
    }

    public async Task<IActionResult> Delete_Student(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _context.Students.FindAsync(id);
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return RedirectToAction("Students");
    }
}