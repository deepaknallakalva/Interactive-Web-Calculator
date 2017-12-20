using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calci.Model
{
    public class Calculator
    {
        public static double Add(double Operand1, double Operand2)
        {
            return Operand1 + Operand2;
        }
        public static double Minus(double Operand1, double Operand2)
        {
            return Operand1 - Operand2;
        }
        public static double Multiply(double Operand1, double Operand2)
        {
            return Operand1 * Operand2;
        }
        public static double Divide(double Operand1, double Operand2)
        {
            return Operand1 / Operand2;
        }

        public static double Power(double Operand1, double Operand2)
        {
            return Math.Pow(Operand1, Operand2);
        }

        public static double Calculate(string st1, string st2, char op)
        {

            char o = Convert.ToChar(op);
            double Result = 0.0;
            try
            {
                if (o == '+')
                {
                    Result = Add(Convert.ToDouble(st1), Convert.ToDouble(st2));
                }
                else if (o == '-')
                {
                    Result = Minus(Convert.ToDouble(st1), Convert.ToDouble(st2));
                }
                else if (o == '*')
                {
                    Result = Multiply(Convert.ToDouble(st1), Convert.ToDouble(st2));
                }
                else if (o == '/')
                {
                    Result = Divide(Convert.ToDouble(st1), Convert.ToDouble(st2));
                }
                else if (o == '^')
                {
                    Result = Power(Convert.ToDouble(st1), Convert.ToDouble(st2));
                    
                }
                else
                {
                    throw new FormatException();
                    
                }


            }
            catch (Exception e)

            {
                Console.WriteLine("exception :" + e.Message);
                Console.ReadLine();
            }
            return Result;
        }
       
    }
}