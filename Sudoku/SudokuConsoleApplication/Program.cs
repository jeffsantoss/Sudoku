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
                    imprimir(sudoku.quadrante);
                else if (userInput == 3)
                    EditarQuadrantes(ref sudoku,quadrantes);
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

        private static void EditarQuadrantes(ref Sudoku sudoku,List<Quadrante> quadrantes)
        {
            int i, j, novoValor;
            EscolherLinhasEColunas(out i, out j, out novoValor);

            var indexquadrante = SelecionarQuadrante(i, j);

            var quadranteAeditar = quadrantes[indexquadrante];

            var valorAntigo = quadranteAeditar.valores[i, j];

            try
            {
                Console.WriteLine("valor antigo: {0} ", valorAntigo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Verifique o valor da sua linha ou coluna");
                return;
            }

            if (novoValor > 9 || novoValor < 0)
            {
                Console.WriteLine("Valor {0} não aceito no sudoku", novoValor);
                Console.ReadLine();
                return;
            }

            quadrantes[indexquadrante].valores[i, j] = novoValor;

            if (quadranteAeditar.temValorRepetido(quadranteAeditar.transformarMatrizEmArray()))
            {
                Console.WriteLine("Existe valores repetidos, valor de '{0}' para '{1}' não alterado.", valorAntigo, novoValor);
                quadranteAeditar.valores[i, j] = valorAntigo;
                Console.ReadLine();
                return;
            }

            var quadrante9x9 = sudoku.quadrante.FormarQuadrante9x9(quadrantes);
            sudoku.quadrante = quadrante9x9;
        }

        private static void EscolherLinhasEColunas(out int i, out int j, out int novoValor)
        {
            Console.WriteLine("Linha: ");
            i = int.Parse(Console.ReadLine());
            Console.WriteLine("Coluna: ");
            j = int.Parse(Console.ReadLine());
            Console.Write("Novo valor: ");
            novoValor = int.Parse(Console.ReadLine());
        }

        public static int SelecionarQuadrante(int linha, int coluna)
        {
            if (coluna <= 2 && linha <= 2)
                return 0;
            else if (coluna <= 5 && linha <= 2)
                return 1;
            else if (coluna <= 8 && linha <= 2)
                return 2;
            else if (coluna <= 2 && linha <= 5)
                return 3;
            else if (coluna <= 5 && linha <= 5)
                return 4;
            else if (coluna <= 8 && linha <= 5)
                return 5;
            else if (coluna <= 2 && linha <= 8)
                return 6;
            else if (coluna <= 5 && linha <= 8)
                return 7;
            else if (coluna <= 8 && linha <= 8)
                return 8;

            return 0;
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
                    Console.Write(" {0},{1}: {2} ", i, j, quadrante.valores[i, j]);
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
