using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Security.Cryptography.X509Certificates;

namespace app7
{
    class Program
    {
        static void Main(string[] args)  
        {
            string[] pwords = {"deed", "noon", "wow", "asa", "civic",
                "racecar", "kayak", "madam", "rotavator", "hey",
                "rastgele", "berber", "selam", "hoscakal"
            };

            foreach (string word in pwords)
            {
                if (word.Length % 2 == 0)
                {
                    List<char> firstHalf = new List<char>(); 
                    List<char> secondHalf = new List<char>();

                    for (int i = 0; i < word.Length/2; i++)
                    {
                        firstHalf.Add(word[i]);
                    }

                    for (int i = word.Length - 1; i > (word.Length/2) - 1; i--)
                    {
                        secondHalf.Add(word[i]);
                    }

                    char[] c1 = firstHalf.ToArray();
                    char[] c2 = secondHalf.ToArray();

                    bool yes = false;
                    for (int i = 0; i < word.Length / 2; i++)
                    {
                        if (c1[i] == c2[i])
                        {
                            yes = true;
                            continue;
                        }
                        else 
                        {
                            yes = false;
                            Console.WriteLine($"{word} not palindrome");
                            break;
                        }
                    }
                    
                    if (yes)
                        Console.WriteLine($"{word} is palindrome");

                }
                else 
                {
                    List<char> firstHalf = new List<char>();
                    List<char> secondHalf = new List<char>();

                    for (int i = 0; i < word.Length/2; i++)
                    {
                        firstHalf.Add(word[i]);
                    }

                    for (int i = word.Length - 1; i > (word.Length / 2); i--)
                    {
                        secondHalf.Add(word[i]); // 0 1 2 3 4
                    }

                    char[] c1 = firstHalf.ToArray();
                    char[] c2 = secondHalf.ToArray();

                    bool yes = false;
                    for (int i = 0; i < word.Length / 2; i++)
                    {
                        if (c1[i] == c2[i])
                        {
                            yes = true;
                            continue;
                        }
                        else
                        {
                            yes = false;
                            Console.WriteLine($"{word} not palindrome");
                            break;
                        }
                    }

                    if (yes)
                        Console.WriteLine($"{word} is palindrome");
                }

            }

        }
    }
}