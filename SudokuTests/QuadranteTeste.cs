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
    public class ProgramTests
    {
        Quadrante quadrante;

        [TestInitialize]
        public void Inicializador(){
            quadrante = new Quadrante(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }

        [TestMethod()]
        public void CriandoUmQuadranteValido()
        {           
            var expected = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            var actual = quadrante.valores;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ValidarUmaLinhaDaMatrizPorIndice_0()
        {
        
            var expected = new int[3] { 1, 2, 3 };

            CollectionAssert.AreEqual(expected, quadrante.linhaQuadrante(0));
        }

        [TestMethod()]
        public void ValidarUmaLinhaDaMatrizPorIndice_1()
        {
        
            var expected = new int[3] { 4, 5, 6 };

            CollectionAssert.AreEqual(expected, quadrante.linhaQuadrante(1));
        }

        [TestMethod()]
        public void ValidarUmaColunaDaMatrizPorIndice_0()
        {
       
            var expected = new int[3] { 1, 4, 7 };

            CollectionAssert.AreEqual(expected, quadrante.colunaQuadrante(0));
        }

        [TestMethod()]
        public void ValidarUmaColunaDaMatrizPorIndice_1()
        {
       
            var expected = new int[3] { 2, 5, 8 };

            CollectionAssert.AreEqual(expected, quadrante.colunaQuadrante(1));
        }
        

    }
}