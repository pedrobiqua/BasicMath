using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicMath.Models
{
    public class BasicsMath
    {
        public long Id { get; set; }
        public string? OperationName { get; set; }
        public bool IsComplete { get; set; }
        public string FunctionExpression { get; set; } = "Nenhuma expressão";
        public List<double>? Result { get; set; }
        public string Messages { get; set; } = "";
        public bool Status { get; set; } = false;
    }
}