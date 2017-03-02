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
            string valor = "-12345";
            valor.ConverterStringParaArray();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ConverterStringParaArrayParaValoresMaioresQue9()
        {
            var valor = "0123456789";

            int[] expected = valor.ConverterStringParaArray();
            int[] actual = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            CollectionAssert.AreEqual(expected, actual);
        }

    }
}