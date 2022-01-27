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
    public class StudentClassMapController : ControllerBase
    {
        private readonly MappingService _mappingService;
        public StudentClassMapController(MappingService mappingService, IRepoGeneric<StudentClassMapper> studentClassMapper)
        {
            _mappingService = mappingService;

        }
        //Add Student
        [HttpPost("MapStudentandClass")]
        public async Task<Object> MapStudentandClass([FromBody] StudentClassMapper studentClassMapper)
        {
            try
            {
                await _mappingService.AddMapping(studentClassMapper);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Add Student
        [HttpGet("GetClassesOfStudent")]
        public async Task<Object> GetClassesOfStudent(int id)
        {
            try
            {
                var result = await _mappingService.GetAllClassesOfStudent(id);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetStudentsForClass")]
        public async Task<Object> GetStudentsForClass(int id)
        {
            try
            {
                var result = await _mappingService.GetStudentsAssignedToClass(id);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete("UnMapStudentandClass")]
        public async Task<Object> UnMapStudentandClass(int studentId,int ClassId)
        {
            try
            {
                return  _mappingService.DeleteMap(studentId,ClassId);
                
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
