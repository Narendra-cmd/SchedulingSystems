using DBLayer.IRepositories;
using DBLayer.Models;
using DBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class StudentService
    {
        private IRepoGeneric<Student> _Student;
        public StudentService(IRepoGeneric<Student> student)
        {
            _Student = student;
        }
        public IEnumerable<Student> GetStudentById(int studetID)
        {
            return _Student.GetById(studetID);
        }

        //GET All Student Details 
        public IEnumerable<Student> GetAllStudents()
        {
            try
            {
                return _Student.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Student by Student Name
        public Student GetStudentByFirstName(string name)
        {
            return _Student.GetAll().Where(x => x.FirstName == name).FirstOrDefault();
        }
        //Add Student
        public async Task<Student> AddStudent(Student Student)
        {
            return await _Student.Create(Student);
        }

        //Delete(Soft) Student 
        public bool DeleteStudentByID(int studentID)
        {

            try
            {
                var student = _Student.GetById(studentID).FirstOrDefault();
               
                    var newItem = student;
                    newItem.IsActive = false;
                    _Student.Update(newItem);
               
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update Student Details
        public bool UpdateStudent(Student Student)
        {
            try
            {
                var DataList = _Student.GetAll().Where(x => x.IsActive == true).ToList();
                foreach (var item in DataList)
                {
                    _Student.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
