using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUnitTestUzduotis.Services
{
    public class MathService : IMathService
    {
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Subtract(int a, int b)
        {
            return (a - b);
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

    public interface IMathService
    {
        int Sum(int a, int b);
        int Subtract(int a, int b);
        int Multiply(int a, int b);
    }
}
