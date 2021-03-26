using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Caesar
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                int mode = 0;
                while (mode == 0)
                {
                    mode = AskForMode();
                }
                switch (mode)
                {
                    case 1:
                        Console.Write("\n Key: ");

                        int key = 0;
                        while (key == 0)
                        {
                            try
                            {
                                key = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                key = 0;
                            }
                        }

                        Console.Write(" Plaintext:   ");
                        string input = Console.ReadLine();

                        Console.WriteLine($" Ciphertext:  {CaesarCrypt.Encrypt(input, key)}");
                        Console.WriteLine("\n");

                        break;

                    case 2:
                        Console.Write("\n Key: ");

                        int key2 = 0;
                        while (key2 == 0)
                        {
                            try
                            {
                                key2 = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                key2 = 0;
                            }
                        }

                        Console.Write(" Ciphertext:  ");
                        string input2 = Console.ReadLine();

                        Console.WriteLine($" Plaintext:   {CaesarCrypt.Decrypt(input2, key2)}");
                        Console.WriteLine("\n");

                        break;

                    case 3:
                        Console.Write(" Ciphertext:  ");
                        string input3 = Console.ReadLine();
                        if (input3.Length > 1)
                        {
                            Console.WriteLine("\nResult:\n");
                            for (int count = 0; count < 27; count++)
                            {
                                Console.WriteLine($"Key: {count} Plaintext:\b");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"{CaesarCrypt.Decrypt(input3, count)}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\b");
                            }
                            Console.WriteLine("\n");
                        }
                        break;

                    case 4:
                        return;
                        break;

                    default:
                        Console.WriteLine("Unfortunately, there is no mode that corresponds to the input.");
                        break;
                }
            }
        }

        public static int AskForMode()
        {
            Console.WriteLine("Select the desired mode:");
            Console.WriteLine("  1: Encrypt");
            Console.WriteLine("  2: Decrypt");
            Console.WriteLine("  3: Bruteforce");
            Console.WriteLine("  4: end program");

            Console.Write("\nmode: ");
            try
            {
                int num = Convert.ToInt32(Console.ReadLine());
                return num;
            }
            catch
            {
                return 0;
            }
        }
    }
}