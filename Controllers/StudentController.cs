using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contexts;
using WebApplication1.Dtos.StudentDtos;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        AppDbContext _context {  get;}

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var datas = _context.Students.ToList();
            return Ok(datas);
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateDto dto)
        {
            await _context.Students.AddAsync(new Student
            {
                Age = dto.Age,
                FirstName = dto.FirstName,
                SurName = dto.SurName,
            });
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(StudentCreateDto dto, int id)
        {
            Student student = await _context.Students.FindAsync(id);
            student.FirstName = dto.FirstName;
            student.SurName = dto.SurName;  
            student.Age = dto.Age;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Student student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
