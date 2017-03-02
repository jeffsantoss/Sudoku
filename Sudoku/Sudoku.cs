using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_
{
    public class Sudoku
    {
        public Quadrante quadrante { get; set; }
        public Sudoku(Quadrante quadrante)
        {
            this.quadrante = quadrante;
        }
        public Sudoku()
        {
        }
        public void validarHorizontais()
        {
            for (int i = 0; i < quadrante.qtdLinhas; i++)
            {
                var linha = quadrante.linhaQuadrante(i);

                if (linha.temValorRepetido())
                    throw new ArgumentException("Verifique sua linha: " + i);
                else if (linha.Contains(0))
                    throw new ArgumentException("Linha com elementos vazios!!");
            }
            
        }

        public void validarVerticais()
        {
            for (int i = 0; i < quadrante.qtdColunas; i++)
            {
                var coluna = quadrante.colunaQuadrante(i);

                if (coluna.temValorRepetido())
                    throw new ArgumentException("Verifique sua coluna: " + i);
                else if(coluna.Contains(0))
                    throw new ArgumentException("Coluna com elementos vazios!!");
            }
        }

        /*
        
        */
    }


    }


