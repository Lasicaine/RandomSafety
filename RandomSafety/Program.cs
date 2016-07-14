//The following sample uses the Cryptography class to simulate the roll of a dice.

using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

class RNGCSP
{
    // Main method.
    public static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Title = "Криптогенератор случайных чисел";
        Console.WriteLine("После ввода значения последовательно нажимате Enter для получения результата.");
        Console.WriteLine("Введите максимальное значение интервала для выборки: ");
        Console.ForegroundColor = ConsoleColor.Green;
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Red;
        int y = 0;
        int[] array = new int[x];
        for (int i = 0; i < x; i++)
        {
            array[i] = y;
            int a = 0;
            while (a == 0)
            {
                int b = 0;
                foreach (int value in array)
                {
                    if (value == y)
                    {
                        b = 1;
                        break;
                    }
                }
                if (b == 1)
                {
                    y = RollDice(x);
                    a = 0;
                }
                else 
                    a = 1;
            }
            Console.WriteLine(y);
            Console.ReadLine();
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Для завершения работы приложения нажмите Enter...");
        Console.ReadLine();
    }

    // This method simulates a roll of the dice. The input parameter is the
    // number of sides of the dice.
    public static int RollDice(int NumSides)
    {
            // Create a byte array to hold the random value.
            byte[] randomNumber = new byte[1];

            // Create a new instance of the RNGCryptoServiceProvider.
            RNGCryptoServiceProvider Gen = new RNGCryptoServiceProvider();

            // Fill the array with a random value.
            Gen.GetBytes(randomNumber);

            // Convert the byte to an integer value to make the modulus operation easier.
           int rand = Convert.ToInt32(randomNumber[0]);

            // Return the random number mod the number
            // of sides.  The possible values are zero-
            // based, so we add one.
            return rand % NumSides + 1;  
    }
}