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
                return new QuadraticFunction();

            } else return new FunctionError(operationName);
	    }

        public BasicsMath MakeOperations(string operationName, double a, double b, double c){

            try
            {
                
                if (operationName.ToLower().Equals("baskara"))
                {
                    return new Bhaskara().MakeMathAccount(operationName, a, b, c);

                } else if(operationName.ToLower().Equals("pitagoras"))
                {
                    return new Pitagoras().MakeMathAccount(operationName, a, b, c);
                } 
                else 
                {
                    return new BasicsMath()
                    {
                        Messages = "Não foi possivel fazer a operação: " + operationName,
                        Status = false
                    };
                }
            }
            catch (System.Exception e)
            {
                return new BasicsMath(){
                    Messages = e.Message,
                    Status = false
                };
            }
        }
    }
}