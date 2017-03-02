using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuConsoleApplication;
using System;
using System.Collections.Generic;
using Sudoku_;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuConsoleApplication.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ConverterStringParaArrayParaValoresQueNaoContemNumero()
        {
            Program.ConverterStringParaArray("-12345");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ConverterStringParaArrayParaValoresMaioresQue9()
        {
            Program.ConverterStringParaArray("0123456789");
        }

        [TestMethod()]
        public void RetornandoQuadrante_0_Se_Linha_Coluna_0_0()
        {
            Assert.AreEqual(0,Program.SelecionarQuadrante(0,0));
        }


        [TestMethod()]
        public void RetornandoQuadrante_4_Se_Linha_Coluna_4_3()
        {
            Assert.AreEqual(4, Program.SelecionarQuadrante(4, 3));
        }

        [TestMethod()]
        public void RetornandoQuadrante_9_Se_Linha_Coluna_8_8()
        {
            Assert.AreEqual(8, Program.SelecionarQuadrante(8, 8));
        }

    }
}