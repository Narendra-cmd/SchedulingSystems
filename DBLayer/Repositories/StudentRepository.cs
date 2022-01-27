using DBLayer.DTO;
using DBLayer.IRepositories;
using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Repositories
{
    public class StudentRepository : IRepoGeneric<Student>
    {
        public SchedulingSystemContext _dbContext;

        public StudentRepository(SchedulingSystemContext SchedulingSystemDbContext)
        {
            _dbContext = SchedulingSystemDbContext;
        }

        public async Task<Student> Create(Student _object)
        {
            var obj = await _dbContext.Students.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }       

        public IEnumerable<Student> GetAll()
        {
            try
            {
                return _dbContext.Students.Where(x => x.IsActive == true).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Student> GetById(int Id)
        {
            return _dbContext.Students.Where(x => x.IsActive == true && x.StudentId == Id);
        }

        public void Update(Student _object)
        {
            _dbContext.Students.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
