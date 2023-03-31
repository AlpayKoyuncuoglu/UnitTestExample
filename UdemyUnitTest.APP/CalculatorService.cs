using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyUnitTest.APP
{
    public class CalculatorService : ICalculatorService
    {
        public int add(int a, int b)
        {
            // return a + b;
            return 0;
        }

        public int multip(int a, int b)
        {
            if (a == b)
            {
                throw new Exception("a=0 olamaz");
            }
            return a * b;
        }
    }
}
