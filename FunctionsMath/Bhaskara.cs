using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicMath.Models;

namespace BasicMath.FunctionsMath
{
    public class Bhaskara : BasicsMath
    {
        public Bhaskara()
        {
            this.OperationName = "Baskara";
            this.FunctionExpression = "-b ± √b² - 4ac / 2a";
        }
    }
}