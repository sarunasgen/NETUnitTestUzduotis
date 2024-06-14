using NETUnitTestUzduotis.Contracts;
using NETUnitTestUzduotis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUnitTestUzduotis.Services
{
    public class StudentService : IStudentService
    {
        private readonly IDatabaseRepository _repository;

        public StudentService(IDatabaseRepository repository)
        {
            _repository = repository;
        }

        public async Task AddStudentAsync(Student student)
        {
            if(student is GoodStudent)
                await _repository.AddGoodStudentAsync((GoodStudent)student);
            else
                await _repository.AddBadStudentAsync((BadStudent)student);
        }

        public async Task<Student> GetStudentAsync(int studentNo)
        {
            return await _repository.GetStudent(studentNo);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _repository.UpdateStudentAsync(student);
        }
    }
}
