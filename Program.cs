using System;

namespace RollingWindowArrays
{
    class Program
    {
        static void Main()
        {
            int n, m;
            
            Console.Write("Δώστε τον αριθμό των γραμμών μεγαλυτερο ισο του 3(n): ");
            n = ReadInteger();
            Console.Write("Δώστε τον αριθμό των στηλών ισο του 3(m): ");
            m = ReadInteger();
            int[,] matrix = new int[n, m];
            Console.WriteLine("Δώστε τα στοιχεία του πίνακα:");
            
            // Εισαγωγή στοιχείων του πίνακα και έλεγχος για integer
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"matrix[{i},{j}]: ");
                    matrix[i, j] = ReadInteger();
                }
            }

            // Εύρεση 3x3 υποπίνακα με το μέγιστο άθροισμα και υπολογισμός του αθροίσματος για τον τρέχοντα 3x3 υποπίνακα
            int maxSum = int.MinValue;
            int startRow = 0, startCol = 0;
            for (int i = 0; i <= n - 3; i++)
            {
                for (int j = 0; j <= m - 3; j++)
                {
                    int currentSum = 0;
                    for (int x = i; x < i + 3; x++)
                    {
                        for (int y = j; y < j + 3; y++)
                        {
                            currentSum += matrix[x, y];
                        }
                    }
                    
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startRow = i;
                        startCol = j;
                    }
                }
            }
            
            Console.WriteLine("\nΗ πλατφόρμα 3x3 με το μέγιστο άθροισμα είναι:");
            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"\nΤο μέγιστο άθροισμα είναι: {maxSum}");
        }
        
        private static int ReadInteger()
        {
            int value;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    return value;
                }
                Console.WriteLine("Μη έγκυρη τιμή! Παρακαλώ δώστε έναν ακέραιο αριθμό.");
            }
        }
    }
}