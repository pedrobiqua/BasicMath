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

        public BasicsMath MakeMathAccount(string expression, double a = 0, double b = 0, double c = 0)
        {

            try
            {
                expression.ToLower();
                if (expression.Equals("baskara"))
                {
                    // Verefica se os campos foram preenchidos
                    if ((a != 0) && (b != 0) && (c != 0))
                    {
                        // Calcular a discriminante b**2 - 4ac
                        double bPow = Math.Pow(b, 2);
                        double ac = ((-4 * a) * c);
                        double discriminante = bPow + ac;
                        if (discriminante < 0)
                        {
                            return new BasicsMath()
                            {
                                FunctionExpression = expression,
                                Messages = "Não é possivel fazer raiz quadrada com número negativo",
                                Status = false
                            };
                        }
                        double resultPlus = (-b + (Math.Sqrt(discriminante))) / (2 * a);
                        double resultMinum = (-b - (Math.Sqrt(discriminante))) / (2 * a);

                        List<double> res = new List<double>();
                        res.Add(resultPlus);
                        res.Add(resultMinum);

                        return new BasicsMath()
                        {
                            FunctionExpression = expression,
                            Result = res,
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
                    Messages = e.Message,
                    Status = false
                };
            }
        }
    }
}