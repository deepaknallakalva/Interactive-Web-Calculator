using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using calci.Model;

namespace calci.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("MyView");
        }

        [HttpGet]
        public ViewResult Calculate()
        {
            return View("Calculate", new CalculateViewModel());
        }

        [HttpPost]
        public ActionResult Calculate(CalculateViewModel c)
        {
            ProcessInput(c);
            ModelState.Clear();
            return View("Calculate", c);

        }

        public void ProcessInput(CalculateViewModel c)
        {
            char input = c.Input;
            c.Input = '\0';
            double t = char.GetNumericValue(input);

            if (input != '.')
            {
                if (t < 0)
                {
                    if (input == '=')
                    {
                        c.Output = "";
                        double result = Calculator.Calculate(c.Operand1, c.Operand2, c.Operator);
                        c.Output = result.ToString();
                        c.OperandIndex = 0;
                        c.Output =  c.Operand1 +c.Operator + c.Operand2+'='+c.Output  ;
                        c.Operand1 = result.ToString(); 
                    }
                    if (input == 'c')
                    {
                        c.Output = "";
                        c.Operand1 = "";
                        c.Operand2 = "";
                        c.OperandIndex = 0;
                    }
                    if (input == '+' || input == '-' || input == '*' || input == '/' || input == '^')
                    {
                        c.Operator = input;
                        c.OperandIndex = 1;
                        c.Operand2 = "";
                        c.Output = input.ToString();
                    }
                }
                else
                {
                    if (c.OperandIndex == 0)
                    {
                        if (String.IsNullOrEmpty(c.Operand2))
                        {
                            c.Operand1 += input;
                            c.Output = c.Operand1;

                        }
                        else
                        {
                            c.Operand1 = "";
                            c.Operand2 = "";
                            c.Operand1 += input;
                            c.OperandIndex = 0;
                            c.Output = c.Operand1;
                        }
                    }
                    else
                    {
                        c.Operand2 += input;
                        c.Output = c.Operand2;
                    }
                }
            }
            else if (c.OperandIndex == 0)
            {
                if (String.IsNullOrEmpty(c.Operand2))
                {
                    c.Operand1 += input;
                    c.Output = c.Operand1;

                }
            }


        }
    }
}
