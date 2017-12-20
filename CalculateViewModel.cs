using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calci.Model
{
    public class CalculateViewModel
    {
        public char Input { get; set; }
        public string Operand1 { get; set; }
        public string Operand2 { get; set; }
        public char Operator { get; set; }
        public double Result { get; set; }
        public int OperandIndex { get; set; }
        public String Output { get; set; }
        public string ErrorMessage { get; set; }
    }
 
}
