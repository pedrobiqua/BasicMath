using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicMath.Models;

namespace BasicMath.FunctionsMath
{
    public class FunctionError : BasicsMath
    {
        public FunctionError(string operationName = "")
        {
            this.FunctionExpression = "Erro no nome da Equação matematica";
            this.Messages = "Não foi encontrado essa operação: " + operationName;
            this.Status = false;
        }
    }
}