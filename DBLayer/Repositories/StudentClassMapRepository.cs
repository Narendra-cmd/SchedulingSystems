using DBLayer.DTO;
using DBLayer.IRepositories;
using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Repositories
{
    public class StudentClassMapRepository:IRepoGeneric<StudentClassMapper>, IRepoExtended<object>
    {
        SchedulingSystemContext _dbContext;
        public StudentClassMapRepository(SchedulingSystemContext SchedulingSystemDbContext)
        {
            _dbContext = SchedulingSystemDbContext;
        }

        public async Task<StudentClassMapper> Create(StudentClassMapper _object)
        {
            var obj = await _dbContext.StudentClassMappers.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public IEnumerable<StudentClassMapper> GetAll()
        {
            try
            {
                return _dbContext.StudentClassMappers.Where(x => x.IsActive == true).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<StudentClassMapper> GetById(int Id)
        {
            try
            {
                return _dbContext.StudentClassMappers.Where(x => x.IsActive == true && x.StudentId==Id).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<object>> GetStudentsForClass(int id)
        {
            try
            {

                IEnumerable<StudentMappingDTO> enumerable = await _dbContext.GetStudentMappingByClassId(id);
                return enumerable;

            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<object>> GetClassesForStudent(int id)
        {
            try
            {
                IEnumerable<ClassMappingDto> enumerable = await _dbContext.GetClassMappingByStuedntId(id);
                return enumerable;               
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(StudentClassMapper _object)
        {
            _dbContext.StudentClassMappers.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
