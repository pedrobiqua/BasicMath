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

            if(operationName.Equals("bhaskara"))
            {
                return new Bhaskara();

            }else if(operationName.Equals("pitagoras"))
            {
                return new Pitagoras();

            } else if( operationName.Equals("função afim") || operationName.Equals("linear function") )
            {
                return new LinearFunction();
                
            } else if(operationName.Equals("função quadratica") || operationName.Equals("quadratic function"))
            {
                return new QuadratcFunction();

            } else return new FunctionError();
	    }
    }
}