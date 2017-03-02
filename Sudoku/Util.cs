using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_
{
    static class Util
    {
        public static int[] transformarMatrizEmArray(this Quadrante quadrante)
        {
            int[] result = new int[quadrante.valores.Length];
            int i = 0;

            foreach (var valor in quadrante.valores)
                result[i++] = valor;

            return result;
        }

        public static bool temValorRepetido(this int[] sequencia)
        {
            var valorRepetido = sequencia.Where(v => sequencia.Count(v1 => v1 == v && v1 != 0) >= 2);

            var result = valorRepetido.ToList();

            return result.Count == 0 ? false : true;
        }

        public static int[] ConverterStringParaArray(string valores)
        {
            if (valores.Length > 9 || valores.Any(c => !char.IsDigit(c)))
                throw new ArgumentException("Verifique sua entrada. Valores aceitos 1-9");

            var resultado = new int[9];
            int indexResultado = 0;

            foreach (var item in valores)
            {
                resultado[indexResultado] = int.Parse(item.ToString());
                indexResultado++;
            }

            return resultado;
        }
    }
}
