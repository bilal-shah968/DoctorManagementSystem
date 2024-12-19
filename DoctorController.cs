using DoctorManagementSystem.Data;
using DoctorManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly DoctorDbContext _context;

    public DoctorController(DoctorDbContext context)
    {
        _context = context;
    }

    // Get all doctors
    
    [HttpGet]
    public IActionResult GetAllDoctors()
    {
        return Ok(_context.Doctors.ToList());
    }

    // Get doctor by ID
    
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetDoctorById(int id)
    {
        var doctor = _context.Doctors.Find(id);
        if (doctor == null) return NotFound();
        return Ok(doctor);
    }

    // Create a new doctor
    
    [HttpPost]
    [Route("Create")]
    public IActionResult CreateDoctor([FromBody] Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
    }

    // Update a doctor
    
    [HttpPut]
    [Route("Update/{id}")]
    public IActionResult UpdateDoctor(int id, [FromBody] Doctor doctor)
    {
        var existingDoctor = _context.Doctors.Find(id);
        if (existingDoctor == null) return NotFound();

        existingDoctor.Name = doctor.Name;
        existingDoctor.Specialization = doctor.Specialization;
        existingDoctor.ContactNumber = doctor.ContactNumber;

        _context.SaveChanges();
        return NoContent();
    }

    // Delete a doctor
  
    [HttpDelete]
    [Route("Delete/{id}")]
    public IActionResult DeleteDoctor(int id)
    {
        var doctor = _context.Doctors.Find(id);
        if (doctor == null) return NotFound();

        _context.Doctors.Remove(doctor);
        _context.SaveChanges();
        return NoContent();
    }
}
