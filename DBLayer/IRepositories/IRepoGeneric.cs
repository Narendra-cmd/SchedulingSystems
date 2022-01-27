using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.IRepositories
{
    public interface IRepoGeneric<T>
    {
        public Task<T> Create(T _object);

        public void Update(T _object);

        public IEnumerable<T> GetAll();

        public IEnumerable<T> GetById(int Id);
       
    }

    public interface IRepoExtended<T>
    {
        public Task<IEnumerable<T>> GetStudentsForClass(int id);

        public Task<IEnumerable<T>> GetClassesForStudent(int id);

    }
    public enum MapItems
    {
        Class =1,
        Student = 2
    }
}
