using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initial = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int[,] numbers = new int[4, 4];
            int numberOfRowsAndColumns = (int)Math.Ceiling(Math.Sqrt(initial.Count()));
            for (int i = 0; i != numberOfRowsAndColumns; i++)
                for (int j = 0; j < numberOfRowsAndColumns; j++)
                {
                    int initialIndex = (i * 4) + j;
                    if (initialIndex < initial.Count())
                    {
                        numbers[i, j] = initial[initialIndex];
                    }
                    numbers[i, j] = 0;
                }
        }
    }
}
