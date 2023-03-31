﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyUnitTest.APP
{
    public class Calculator
    {
        private ICalculatorService _calculatorService;
        public Calculator(ICalculatorService calculatorService)
        {
            this._calculatorService = calculatorService;
        }

        public int add(int a, int b)
        {
            return _calculatorService.add(a, b);
            //if (a == 0 || b == 0)
            //{
            //    return 0;
            //}
            //return a + b;
        }
        public int multip(int a, int b)
        {
            return _calculatorService.multip(a, b);
        }
    }
}
