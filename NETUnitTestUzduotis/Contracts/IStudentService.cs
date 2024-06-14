using NETUnitTestUzduotis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUnitTestUzduotis.Contracts
{
    public interface IStudentService
    {
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task<Student> GetStudentAsync(int studentNo);
    }
}
