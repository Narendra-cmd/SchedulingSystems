using DBLayer.DTO;
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
   public  class MappingService
    {
        public readonly IRepoGeneric<StudentClassMapper> _StudentClassMapperRepo;
        public readonly IRepoExtended<object> _StudentClassMapperRepoEx;
        public MappingService(IRepoGeneric<StudentClassMapper> studentClassMapper, IRepoExtended<object> StudentClassMapperRepoEx)
        {
            _StudentClassMapperRepo = studentClassMapper;
            _StudentClassMapperRepoEx = StudentClassMapperRepoEx;
        }

        //GET All StudentWithClass Details 
        public IEnumerable<StudentClassMapper> GetMapping()
        {
            try
            {
                return _StudentClassMapperRepo.GetAll().OrderBy(x=>x.StudentId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET StudentWithClass Details 
        public async Task<IEnumerable<StudentMappingDTO>> GetStudentsAssignedToClass(int ID)
        {
            try
            {
                IEnumerable<StudentMappingDTO> lst = (IEnumerable<StudentMappingDTO>)await _StudentClassMapperRepoEx.GetStudentsForClass(ID);
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// GetAllClassesOfStudent
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ClassMappingDto>> GetAllClassesOfStudent(int ID)
        {
            try
            {
                IEnumerable<ClassMappingDto> lst = (IEnumerable<ClassMappingDto>)await _StudentClassMapperRepoEx.GetClassesForStudent(ID);
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add Mapping
        public async Task<StudentClassMapper> AddMapping(StudentClassMapper studentClassMapper)
        {
            return await _StudentClassMapperRepo.Create(studentClassMapper);
        }

        //Delete(Soft) Student 
        public bool DeleteMap(int studentID,int classID)
        {

            try
            {
                var DataList = _StudentClassMapperRepo.GetAll().Where(x => x.StudentId == studentID).ToList();
                foreach (var item in DataList)
                {
                    if (item.ClassId == classID)
                    {
                        var newItem = item;
                        newItem.IsActive = false;
                        _StudentClassMapperRepo.Update(newItem);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update Student Details
        public bool UpdateStudent(StudentClassMapper studentClassMapper)
        {
            try
            {
                var DataList = _StudentClassMapperRepo.GetAll().Where(x => x.IsActive == true).ToList();
                foreach (var item in DataList)
                {
                    _StudentClassMapperRepo.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
