using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicMath.FunctionsMath;
using BasicMath.Models;

namespace BasicMath
{
    public class Functions
    {
        public BasicsMath ShowFunction(string operationName){		

            if(operationName.Equals("bhaskara")){
                return new Bhaskara();
            }else if(operationName.Equals("pitagoras")){
                return new Pitagoras();
            }else return new FunctionError();
	    }
    }
}