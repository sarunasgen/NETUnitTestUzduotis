using Dapper;
using NETUnitTestUzduotis.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUnitTestUzduotis.Repositories
{
    public class DatabaseRepository
    {
        private readonly string _connectionString;

        public DatabaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task AddStudentAsync(Student student)
        {
            using (var connection = GetConnection())
            {
                var parameters = new
                {
                    student.StudentNo,
                    student.FirstName,
                    student.LastName,
                    student.DateOfBirth,
                    student.AverageMark
                };

                await connection.ExecuteAsync("AddStudent", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task AddGoodStudentAsync(GoodStudent student)
        {
            using (var connection = GetConnection())
            {
                var parameters = new
                {
                    student.StudentNo,
                    student.FirstName,
                    student.LastName,
                    student.DateOfBirth,
                    student.AverageMark,
                    student.IsVeryGood

                };

                await connection.ExecuteAsync("AddStudent", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task AddBadStudentAsync(BadStudent student)
        {
            using (var connection = GetConnection())
            {
                var parameters = new
                {
                    student.StudentNo,
                    student.FirstName,
                    student.LastName,
                    student.DateOfBirth,
                    student.AverageMark,
                    student.WhySoBad,
                };

                await connection.ExecuteAsync("AddStudent", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateStudentAsync(Student student)
        {
            using (var connection = GetConnection())
            {
                var parameters = new
                {
                    student.StudentNo,
                    student.FirstName,
                    student.LastName,
                    student.DateOfBirth,
                    student.AverageMark
                };

                await connection.ExecuteAsync("UpdateStudent", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<Student> GetStudent(int id)
        {
            return null;
        }
    }
}
