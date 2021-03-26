using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Caesar
{
    internal class CaesarCrypt
    {
        private static readonly char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public static char[] CleanString(string text)
        {
            string plain = text.ToLower();
            char[] allowedChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ', '.', '!', '?', ',', ':', ';', '&' };

            StringBuilder builder = new StringBuilder();

            foreach (var i in plain)
            {
                if (allowedChars.Contains(i))
                {
                    builder.Append(i);
                }
            }

            char[] arr;
            arr = builder.ToString().ToCharArray(0, builder.ToString().Length);

            return arr;
        }

        private static string MoveRight(char[] inp, int key)
        {
            char[] output = inp;

            for (int i = 0; i < output.Length; i++)
            {
                char letter = output[i];
                if (alphabet.Contains(letter))
                {
                    letter = (char)(letter + key);
                    if (letter < 'a')
                    {
                        letter = (char)(letter + 26);
                    }
                    else if (letter > 'z')
                    {
                        letter = (char)(letter - 26);
                    }

                    output[i] = letter;
                }
                else
                {
                    output[i] = letter;
                }
            }
            //Console.WriteLine(new string(output));
            return new string(output);
        }

        public static string Encrypt(string plaintext, int key)
        {
            if (plaintext == null || plaintext.Length < 1)
            {
                return "error";
            }
            char[] plain = CleanString(plaintext);

            return MoveRight(plain, key);
        }

        public static string Decrypt(string ciphertext, int key)
        {
            if (ciphertext == null || ciphertext.Length < 1)
            {
                return "error";
            }
            char[] cipher = CleanString(ciphertext);

            return MoveRight(cipher, (-key));
        }

        public static int Probability(string plaintext, string[] words)
        {
            if (plaintext.Length < 1 || words.Length < 1)
                return 0;

            int count = 0;
            foreach (string word in words)
            {
                string lowerWord = word.ToLower();
                if (plaintext.Contains(lowerWord))
                {
                    count++;
                }
            }
            return count;
        }
    }
}