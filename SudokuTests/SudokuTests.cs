using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_.Tests
{
    [TestClass()]
    public class SudokuTests
    {
        Sudoku sudoku;

        [TestInitialize]
        public void Inicializar()
        {
            sudoku = new Sudoku();
        }
        
 

        [TestMethod()]
        public void Retorna9LinhasE9Colunas()
        {
            var quadrantes = new List<Quadrante>();

            for (int i = 0; i < 9; i++)
            {
                quadrantes.Add(new Quadrante(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
            }

            var quadranteCompleto = new Quadrante().FormarQuadrante9x9(quadrantes);

            Assert.AreEqual(9, quadranteCompleto.qtdColunas);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ErroAoPassarMenosQue9Quadrantes()
        {
            var quadrantes = new List<Quadrante>();

            Quadrante quadrante = new Quadrante();

            quadrantes.Add(new Quadrante(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
            quadrantes.Add(new Quadrante(new int[] { 2, 4, 6, 7, 8, 9, 5, 1, 3 }));
            quadrantes.Add(new Quadrante(new int[] { 8, 9, 7, 6, 5, 4, 3, 2, 1 }));

            quadrante.FormarQuadrante9x9(quadrantes);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidarSudokuCompletoComValoresRepetidosNaHorizontalEmQuadrante9x9()
        {
            var quadrantes = new List<Quadrante>();

            Quadrante quadrante = new Quadrante();

            // quadrantes 1-2-3
            quadrantes.Add(new Quadrante(new int[] { 9, 4, 7, 6, 1, 3, 8, 5, 2 }));
            quadrantes.Add(new Quadrante(new int[] { 0, 0, 7, 0, 0, 0, 4, 9, 3 }));
            quadrantes.Add(new Quadrante(new int[] { 0, 0, 0, 0, 0, 0, 1, 7, 6 }));

            // quadrantes 4-5-6
            quadrantes.Add(new Quadrante(new int[] { 1, 2, 9, 5, 7, 8, 3, 6, 4 }));
            quadrantes.Add(new Quadrante(new int[] { 3, 8, 4, 9, 2, 6, 7, 1, 5 }));
            quadrantes.Add(new Quadrante(new int[] { 5, 6, 7, 4, 3, 1, 2, 8, 9 }));

            // quadrantes 7-8-9
            quadrantes.Add(new Quadrante(new int[] { 2, 9, 1, 7, 8, 5, 4, 3, 6 }));
            quadrantes.Add(new Quadrante(new int[] { 6, 3, 8, 2, 4, 1, 5, 7, 9 }));
            quadrantes.Add(new Quadrante(new int[] { 7, 4, 5, 6, 9, 3, 8, 1, 2 }));


            var quadranteCheio = quadrante.FormarQuadrante9x9(quadrantes);

            sudoku.quadrante = quadranteCheio;

            sudoku.validarHorizontais();
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidarSudokuCompletoComValoresRepetidosNaVerticalEmQuadrante9x9()
        {
            var quadrantes = new List<Quadrante>();

            Quadrante quadrante = new Quadrante();

            // quadrantes 1-2-3
            quadrantes.Add(new Quadrante(new int[] { 9, 4, 7, 6, 1, 3, 8, 5, 2 }));
            quadrantes.Add(new Quadrante(new int[] { 1, 6, 2, 8, 5, 7, 4, 9, 3 }));
            quadrantes.Add(new Quadrante(new int[] { 3, 5, 8, 9, 2, 4, 1, 7, 6 }));

            // quadrantes 4-5-6
            quadrantes.Add(new Quadrante(new int[] { 9, 0, 0, 0, 0, 0, 0, 0, 0 }));
            quadrantes.Add(new Quadrante(new int[] { 3, 8, 4, 9, 2, 6, 7, 1, 5 }));
            quadrantes.Add(new Quadrante(new int[] { 5, 6, 7, 4, 3, 1, 2, 8, 9 }));

            // quadrantes 7-8-9
            quadrantes.Add(new Quadrante(new int[] { 8, 0, 0, 0, 0, 0, 0, 0, 0 }));
            quadrantes.Add(new Quadrante(new int[] { 6, 3, 8, 2, 4, 1, 5, 7, 9 }));
            quadrantes.Add(new Quadrante(new int[] { 7, 4, 5, 6, 9, 3, 8, 1, 2 }));


            var quadranteCheio = quadrante.FormarQuadrante9x9(quadrantes);

            sudoku.quadrante = quadranteCheio;

            sudoku.validarVerticais();
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidarSudokuCompletoComValoresRepetidosNoQuadranteEspecificoEmQuadrante9x9()
        {

            var quadrantes = new List<Quadrante>();

            Quadrante quadrante = new Quadrante();

            // quadrantes 1-2-3
            quadrantes.Add(new Quadrante(new int[] { 9, 9, 7, 6, 1, 3, 8, 5, 2 }));
            quadrantes.Add(new Quadrante(new int[] { 1, 6, 2, 8, 5, 7, 4, 9, 3 }));
            quadrantes.Add(new Quadrante(new int[] { 3, 5, 8, 9, 2, 4, 1, 7, 6 }));

            // quadrantes 4-5-6
            quadrantes.Add(new Quadrante(new int[] { 1, 2, 9, 5, 7, 8, 3, 6, 4 }));
            quadrantes.Add(new Quadrante(new int[] { 3, 8, 4, 9, 2, 6, 7, 1, 5 }));
            quadrantes.Add(new Quadrante(new int[] { 5, 6, 7, 4, 3, 1, 2, 8, 9 }));

            // quadrantes 7-8-9
            quadrantes.Add(new Quadrante(new int[] { 2, 9, 1, 7, 8, 5, 4, 3, 6 }));
            quadrantes.Add(new Quadrante(new int[] { 6, 3, 8, 2, 4, 1, 5, 7, 9 }));
            quadrantes.Add(new Quadrante(new int[] { 7, 4, 5, 6, 9, 3, 8, 1, 2 }));
        }
    }
}

