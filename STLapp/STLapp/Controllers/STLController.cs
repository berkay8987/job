using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STLapp.Data;
using STLapp.Models;

namespace STLapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class STLController : ControllerBase
    {
        private readonly STLContext _context;

        public STLController(STLContext context)
        {
            _context = context;
        }

        [HttpGet("GetStudents")]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var students = _context.Students;
            return Ok(students);
        }

        [HttpGet("GetStudents/{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = _context.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student == null) { return BadRequest("Student Not Found!"); }
            return Ok(student);
        }

        [HttpGet("GetTeachers")]
        public async Task<ActionResult<List<Teacher>>> GetTeachers()
        {
            var teachers = _context.Teachers;
            return Ok(teachers);
        }
        
        [HttpGet("GetTeachers/{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherById(int id)
        {
            var teacher = _context.Teachers.Where(x => x.Id == id).FirstOrDefault();
            if (teacher == null) { return BadRequest("Teacher Not Found!"); }
            return Ok(teacher);
        }

        [HttpGet("GetLessons")]
        public async Task<ActionResult<List<Lesson>>> GetLessons()
        {
            var lessons = _context.Lessons;
            return Ok(lessons);
        }
        
        [HttpGet("GetLessons/{id}")]
        public async Task<ActionResult<Lesson>> GetLessonById(int id)
        {
            var lesson = _context.Lessons.Where(x => x.Id == id).FirstOrDefault();
            if (lesson == null) { return BadRequest("Lesson Not Found!"); }
            return Ok(lesson);
        }

        [HttpGet("GetLessonPrograms")]
        public async Task<ActionResult<List<LessonProgram>>> GetLessonPrograms()
        {
            var lessonPrograms = _context.LessonPrograms;
            return Ok(lessonPrograms);
        }

        [HttpGet("GetLessonPrograms/{id}")]
        public async Task<ActionResult<Lesson>> GetLessonProgramById(int id)
        {
            var lessonProgram = _context.LessonPrograms.Where(x => x.Id == id).FirstOrDefault();
            if (lessonProgram == null) { return BadRequest("lessonProgram Not Found!"); }
            return Ok(lessonProgram);
        }

        [HttpPost("PostStudent")]
        public async Task<ActionResult<List<Student>>> PostStudent([FromBody]Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok(_context.Students);
        }

        [HttpPost("PostTeacher")]
        public async Task<ActionResult<List<Teacher>>> PostTeacher([FromBody]Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return Ok(_context.Teachers);
        }

        [HttpPost("PostLesson")]
        public async Task<ActionResult<List<Lesson>>> PostLesson([FromBody]Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            _context.SaveChanges();
            return Ok(_context.Lessons);
        }

        [HttpPost("PostLessonProgram")]
        public async Task<ActionResult<List<LessonProgram>>> PostLessonProgram([FromBody] LessonProgram lessonProgram)
        {
            _context.LessonPrograms.Add(lessonProgram);
            _context.SaveChanges();
            return Ok(_context.LessonPrograms);
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = _context.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student == null) { return BadRequest("Student Not Found!"); }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("DeleteTeacher/{id}")]
        public async Task<ActionResult<Student>> DeleteTeacher(int id)
        {
            var teacher = _context.Teachers.Where(x => x.Id == id).FirstOrDefault();
            if (teacher == null) { return BadRequest("Teacher Not Found!"); }
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }

        [HttpDelete("DeleteLesson/{id}")]
        public async Task<ActionResult<Student>> DeleteLesson(int id)
        {
            var lesson = _context.Lessons.Where(x => x.Id == id).FirstOrDefault();
            if (lesson == null) { return BadRequest("Lesson Not Found!"); }
            _context.Lessons.Remove(lesson);
            _context.SaveChanges();
            return Ok(lesson);
        }

        [HttpDelete("DeleteLessonProgram/{id}")]
        public async Task<ActionResult<Student>> DeleteLessonProgram(int id)
        {
            var lessonProgram = _context.LessonPrograms.Where(x => x.Id == id).FirstOrDefault();
            if (lessonProgram == null) { return BadRequest("LessonProgram Not Found!"); }
            _context.LessonPrograms.Remove(lessonProgram);
            _context.SaveChanges();
            return Ok(lessonProgram);
        }

        [HttpPut("PutStudent")]
        public async Task<ActionResult<Student>> PutStudent([FromBody] Student student)
        {
            var _student = _context.Students.Where(x => x.Id == student.Id).FirstOrDefault();
            if (_student == null) { return BadRequest("Student Not Found!"); }
            
            _student.FirstName = student.FirstName;
            _student.LastName = student.LastName;
            _student.Age = student.Age;
            _student.Title = student.Title;
            _student.YearStarted = student.YearStarted;

            _context.SaveChanges();

            return Ok(student);
        }

        [HttpPut("PutTeacher")]
        public async Task<ActionResult<Teacher>> PutTeacher([FromBody] Teacher teacher)
        {
            var _teacher = _context.Teachers.Where(x => x.Id == teacher.Id).FirstOrDefault();
            if (_teacher == null) { return BadRequest("Teacher Not Found!"); }

            _teacher.FirstName = teacher.FirstName;
            _teacher.LastName = teacher.LastName;
            _teacher.Age = teacher.Age;
            _teacher.Branch = teacher.Branch;
            _teacher.DateStartedWorking = teacher.DateStartedWorking;

            _context.SaveChanges();

            return Ok(teacher);
        }

        [HttpPut("PutLesson")]
        public async Task<ActionResult<Lesson>> PutLesson([FromBody] Lesson lesson)
        {
            var _lesson = _context.Lessons.Where(x => x.Id == lesson.Id).FirstOrDefault();
            if (_lesson == null) { return BadRequest("Lesson Not Found!"); }

            _lesson.Name = lesson.Name;

            _context.SaveChanges();

            return Ok(lesson);
        }

        [HttpPut("PutLessonProgram")]
        public async Task<ActionResult<LessonProgram>> PutLessonProgram([FromBody] LessonProgram lessonProgram)
        {
            var _lessonProgram = _context.LessonPrograms.Where(x => x.Id == lessonProgram.Id).FirstOrDefault();
            if (_lessonProgram == null) { return BadRequest("Lesson Not Found!"); }

            _lessonProgram.StudentId = lessonProgram.StudentId;
            _lessonProgram.LessonId = lessonProgram.LessonId;
            _lessonProgram.TeacherId = lessonProgram.TeacherId;

            _context.SaveChanges();

            return Ok(lessonProgram);
        }
    }
}
