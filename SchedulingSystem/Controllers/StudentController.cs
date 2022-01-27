using BusinessLayer.Services;
using DBLayer.IRepositories;
using DBLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _StudentService;
        private readonly IRepoGeneric<Student> _Student;

        public StudentController(IRepoGeneric<Student> Student, StudentService studentService)
        {
            _StudentService = studentService;
            _Student = Student;

        }
        //Add Student
        [HttpPost("AddStudent")]
        public async Task<Object> AddStudent([FromBody] Student Student)
        {
            try
            {
                await _StudentService.AddStudent(Student);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete Student
        [HttpDelete("DeleteStudent")]
        public bool DeleteStudent(int StudentId)
        {
            try
            {
                _StudentService.DeleteStudentByID(StudentId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Update Student
        [HttpPut("UpdateStudent")]
        public bool UpdateStudent(Student Object)
        {
            try
            {
                _StudentService.UpdateStudent(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //GET Student by Name
        [HttpGet("GetStudentByFirstName")]
        public Object GetAllStudentByName(string fName)
        {
            var data = _StudentService.GetStudentByFirstName(fName);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Student
        [HttpGet("GetAllStudents")]
        public Object GetAllStudents()
        {
            var data = _StudentService.GetAllStudents();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
