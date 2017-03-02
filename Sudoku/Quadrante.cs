using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_
{
    public class Quadrante
    {
        public int[,] valores { get; set; }       
        public int qtdLinhas = 3;
        public int qtdColunas = 3;

        public Quadrante() { }

        public Quadrante(int[] valoresLinhas)
        {
            var valoresMaioresMenores = valoresLinhas.Where(v => v > 9 || v < 0);
          
            if (this.temValorRepetido(valoresLinhas) || valoresMaioresMenores.ToList() == null)
                throw new ArgumentException("Valores só podem ser passados entre 1-9 não repetidos");

            PreencherQuadrante(valoresLinhas);
        }

        private void PreencherQuadrante(int[] valoresLinhas)
        {
            this.valores = new int[this.qtdLinhas, this.qtdColunas];

            int indexRown = 0;

            if (valoresLinhas.Length > 9)
            {
                PreencherQuadrante9x9(valoresLinhas);
                return;
            }

            for (int i = 0; i < qtdLinhas; i++)
            {
                for (int j = 0; j < qtdColunas; j++)
                {
                    valores[i, j] = valoresLinhas[indexRown];
                    indexRown++;
                }
            }
        }

        private void PreencherQuadrante9x9(int[] valoresLinhas)
        {
            var listAux = new int[9];
            int indexListaux = 0, k = 0;

            listAux[listAux.Length - 1] = -1;

            for (int i = 0; i < qtdLinhas; i++)
            {
                for (int z = 0; k < valoresLinhas.Length;)
                {
                    listAux[indexListaux] = valoresLinhas[k];
                    indexListaux++;
                    z++;

                    if (listAux[listAux.Length - 1] != -1)
                        break;

                    if (z == 3)
                    {
                        k += 7;
                        z = 0;
                    }
                    else
                    {
                        k++;
                    }

                }

                for (int j = 0; j < qtdColunas; j++)
                {
                    valores[i, j] = listAux[j];
                }

                listAux[listAux.Length - 1] = -1;

                if (k != 26 && k != 53 && k != 80)
                    k -= 17;
                else
                    k++;

                indexListaux = 0;
            }
        }

        public Quadrante FormarQuadrante9x9(List<Quadrante> quadrantes)
        {

            if (quadrantes.Count != 9)
                throw new ArgumentException("Quantidade de quadrantes inválidos para formar o sudoku");

            Quadrante sudoku = new Quadrante();

            sudoku.qtdLinhas = 0;
            sudoku.qtdColunas = 0;

            List<int> matrizes = new List<int>();

            foreach (var quadrante in quadrantes)
            {
                matrizes.AddRange(quadrante.transformarMatrizEmArray());
            }

            for (int i = 0; i < quadrantes.Count / 3; i++)
            {
                sudoku.qtdLinhas += quadrantes[i].qtdLinhas;
                sudoku.qtdColunas += quadrantes[i].qtdColunas;
            }

            sudoku.PreencherQuadrante(matrizes.ToArray());

            return sudoku;
        }
        public int[] linhaQuadrante(int index)
        {
            var result = new int[this.qtdColunas];

            for (int i = 0; i < this.qtdColunas; i++)
            {
                result[i] = this.valores[index, i];
            }

            return result;
        }
        public int[] colunaQuadrante(int index)
        {
            var result = new int[this.qtdLinhas];

            for (int i = 0; i < this.qtdLinhas; i++)
            {
                result[i] = this.valores[i, index];
            }

            return result;
        }
        public int[] transformarMatrizEmArray()
        {
            int[] result = new int[this.valores.Length];
            int i = 0;

            foreach (var valor in this.valores)
                result[i++] = valor;

            return result;
        }
        public bool temValorRepetido(int[] sequencia)
        {
            var valorRepetido = sequencia.Where(v => sequencia.Count(v1 => v1 == v && v1 != 0) >= 2);

            var result = valorRepetido.ToList();

            return result.Count == 0 ? false : true;
        } 

    }
}

