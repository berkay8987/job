using System;

namespace app8
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
                bool ok = word.SequenceEqual(word.Reverse());
                Console.WriteLine($"{word} is {ok}");

                /*
                int i = 0;
                int j = word.Length - 1;

                bool yes = false;
                while (true)
                {
                    if (word[i] == word[j])
                    {
                        i++;
                        j--;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                if (yes)
                    Console.WriteLine($"{word} is polindrome");
                */
            }

        }
    }
}