using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicMath.Models;

namespace BasicMath.FunctionsMath
{
    public class Pitagoras : BasicsMath
    {
        private bool _isRightTriangle;
        public bool isRightTriangle {get => _isRightTriangle; set {_isRightTriangle = value;}}
        public Pitagoras()
        {
            this.OperationName = "Pitagoras";
            this.FunctionExpression = "c² = a² + b²";
        }

        public BasicsMath MakeMathAccount(string expression, double a = 0, double b = 0, double c = 0)
        {

            try
            {
                if (expression.ToLower().Equals("pitagoras"))
                {
                    if ((a != 0) && (b != 0))
                    {
                        List<double> result = new List<double>();
                        double aPow = Math.Pow(a, 2);
                        double bPow = Math.Pow(b, 2);

                        result.Add(aPow + bPow);


                        return new Pitagoras()
                        {
                            _isRightTriangle = true,
                            OperationName = expression,
                            Result = result,
                            Messages = "Operação realizada com sucesso",
                            Status = true
                        };
                    }   
                }
                return new BasicsMath()
                {
                    Messages = "Não foi possivel fazer a operação: " + expression,
                    Status = false
                };
            }
            catch (System.Exception e)
            {
                return new BasicsMath()
                {
                    Messages = "Erro: " + e.Message,
                    Status = false
                };
            }
        }
    }
}