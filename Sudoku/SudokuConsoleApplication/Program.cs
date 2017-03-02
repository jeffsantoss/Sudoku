using System;
using System.Collections.Generic;
using Sudoku_;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SudokuConsoleApplication
{
    public class Program
    {
        static void Main()
        {        
            Sudoku sudoku = new Sudoku(new Quadrante());
            var quadrantes = new List<Quadrante>();

            int userInput = 0;

            do
            {
                userInput = Menu();

                if (userInput == 1)
                    sudoku.quadrante = CriarSudoku(ref quadrantes);
                else if (userInput == 2)
                {
                    sudoku.quadrante = sudoku.quadrante.FormarQuadrante9x9(quadrantes);
                    imprimir(sudoku.quadrante);
                }
                else if (userInput == 3)
                    EditarQuadrantes(ref quadrantes);
                else if (userInput == 4)
                    Validar(sudoku);

                Console.Clear();
            } while (userInput != 5);
        }

        private static int Menu()
        {
            int userInput;
            Console.WriteLine("SUDOKU");
            Console.WriteLine("");
            Console.WriteLine("1. Criar Sudoku");
            Console.WriteLine("2. Imprimir Sudoku");
            Console.WriteLine("3. Editar Valores");
            Console.WriteLine("4. Validar sudoku");
            Console.WriteLine("5. Fechar");

            userInput = int.Parse(Console.ReadLine());
            return userInput;
        }

        private static void Validar(Sudoku sudoku)
        {
            try
            {
                sudoku.validarHorizontais();
                sudoku.validarVerticais();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Parabéns, você preencheu perfeitamente o sudoku!");
            Console.ReadLine();

        }

        private static void EditarQuadrantes(ref List<Quadrante> quadrantes)
        {
          
            Console.Write("Quadrante: ");
            var index = int.Parse(Console.ReadLine());
            int[] valoresQuadrante = index.QuandranteporIndex(quadrantes);


            Console.Write("Valores do quadrante: ");
            foreach (var item in valoresQuadrante)
                Console.Write(item + "  ");

            Console.WriteLine("");

            Console.Write("Posição: ");
            var posicao = int.Parse(Console.ReadLine());
            Console.Write("Novo valor: ");
            var novoValor = int.Parse(Console.ReadLine());

            if (novoValor > 9 || novoValor < 0)
            {
                Console.WriteLine("Valor {0} não aceito no sudoku", novoValor);
                Console.ReadLine();
                return;
            }

            if (posicao > 8 || posicao < 0)
            {
                Console.WriteLine("Posicao inválida!", posicao);
                Console.ReadLine();
                return;
            }

            var valorAntigo = valoresQuadrante[posicao];
            
            if (valoresQuadrante.Contains(novoValor))
            {
                Console.WriteLine("Existe valores repetidos, valor de '{0}' para '{1}' não alterado.", valorAntigo, novoValor);
                Console.ReadLine();
                return;
            }

            valoresQuadrante[posicao] = novoValor;
            quadrantes[index].PreencherQuadrante(valoresQuadrante);
        }

        public static Quadrante CriarSudoku(ref List<Quadrante> quadrantes)
        {
            Sudoku sudoku = new Sudoku();
            
            for (int i = 0; i < 9;)
            {
                Console.Write("Quadrante 0{0}: ", i + 1);

                var quadrante = Console.ReadLine();

                try
                {
                    quadrantes.Add(new Quadrante(ConverterStringParaArray(quadrante)));
                    i++;
                }
                catch(ArgumentException excp)
                {
                    Console.WriteLine(excp.Message);
                    Console.ReadLine();
                    continue;
                }
            }

            return new Quadrante().FormarQuadrante9x9(quadrantes);
        }

        public static void imprimir(Quadrante quadrante)
        {
            Console.WriteLine("");
            Console.WriteLine("");

            if (quadrante.valores == null)
            {
                Console.WriteLine("Preencha os quadrantes!");
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < quadrante.qtdLinhas; i++)
            {
                for (int j = 0;j < quadrante.qtdColunas; j++)
                {
                    Console.Write(" {0} ", quadrante.valores[i, j]);
                    if (j == 2 || j == 5)
                        Console.Write("\t");                  
                }
                Console.Write("\n");
                  if (i == 2 || i == 5)
                        Console.Write("\n\n");
            }
           
            Console.ReadLine();
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
