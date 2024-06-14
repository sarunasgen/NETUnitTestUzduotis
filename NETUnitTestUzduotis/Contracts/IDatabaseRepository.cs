using NETUnitTestUzduotis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUnitTestUzduotis.Contracts
{
    public interface IDatabaseRepository
    {
        Task AddStudentAsync(Student student);
        Task AddGoodStudentAsync(GoodStudent student);
        Task AddBadStudentAsync(BadStudent student);
        Task UpdateStudentAsync(Student student);
        Task<Student> GetStudent(int id);
    }
}
