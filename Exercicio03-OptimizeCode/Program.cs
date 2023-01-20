using System;
using System.Collections;
using System.Linq;

public class Teste
{
    static void Main(string[] args)
    {
        int[,] array1 = new int[2,3] { { 1, 2, 3 }, { 4, 5, 6 }};
        
        int[,] array2 = new int[3, 2] { { 7, 8, }, { 9, 10 }, { 11, 12} };
        
        Matrix a = new Matrix(array1); //converte a array 2d em unidimensional na classe Matrix
        Matrix b = new Matrix(array2); 
        var result = Exercise.Multiply(a, b); 
        
        for (int i = 0; i < result.Rows; i++) //for passando por cada linha
        {
            for (int j = 0; j < result.Columns; j++) //for passando por cada coluna
            {
                Console.Write(string.Format("{0} ", result[i, j])); //escrevendo o resultado
            }
            //Console.Write(Environment.NewLine + Environment.NewLine); //primeira forma de adicionar a quebra de linha
            Console.WriteLine("\n"); //segunda forma mais compacta de adicionar a quebra de linha
        }
    }
}

public class Matrix : IEnumerable
{

    private int[] _data;

    public int Rows { get; }
    public int Columns { get; }
    public int this[int row, int col]
    {
        get { return _data[row * Columns + col]; }
        set { _data[row * Columns + col] = value; }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _data.GetEnumerator();
    }

    public Matrix(int[,] value)
    {
        Rows = value.GetLength(0); //retorna o tamanho das linhas
        Columns = value.GetLength(1); //retorna o tamanho das colunas
        _data = new int[Rows * Columns]; //instancia a matriz unidimensional com o tamanho correto, multiplicando o número de linhas pelo número de colunas
        int index = 0;
        for (int row = 0; row < Rows; row++) //percorre as linhas da matriz 2d
        { 
            for (int column = 0; column < Columns; column++) // percorre as colunas da matriz 2d
            { 
                _data[index++] = value[row, column]; //armazena os valores na matriz unidimensional
            }
        }
    }
}

public static class Exercise
{
    public static Matrix Multiply(Matrix a, Matrix b)
    {
        var result = new Matrix(new int[a.Rows, b.Columns]);
        for (int i = 0; i < result.Rows; i++) //for passando pelas linhas
        {
            for (int j = 0; j < result.Columns; j++) //for passando pelas colunas
            {
                result[i, j] = 0; //resultado da multiplicação inicializado
                for (int k = 0; k < a.Columns; k++)
                {
                    result[i, j] += (a[i, k] * b[k, j]); //realiza a multiplicação dos valores da matriz
                }
            }
        }
        return result;
    }
}

