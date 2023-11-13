using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FibonacciService
{
    public class FibonacciService : IFibonacciService
    {
        public long ObterProximoFibonacci(int posicao)
        {
            if (posicao < 0)
            {
                throw new FaultException("A posição deve ser um número não negativo.");
            }

            long resultado = CalcularFibonacci(posicao + 1);
            return resultado;
        }

        private long CalcularFibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            long a = 0, b = 1;

            for (int i = 2; i < n; i++)
            {
                long temp = a + b;
                a = b;
                b = temp;
            }

            return b;
        }
    }

}
