using System;
using System.Threading.Tasks;

namespace examp2
{
    class Program
    { 
        static async Task Main()
        {
            Console.WriteLine("Uygulama Basladi");
    
            int sonuc = await IslemAsync(5, 3);
            string word = await IslemAsync2();
            Console.WriteLine(word);
    
            Console.WriteLine($"Uygulamaf tamamlandi sonuc: {sonuc}");
        }

        static async Task<int> IslemAsync(int x, int y)
        {
            Console.WriteLine("Islem basladi");
 
            await Task.Delay(4000);

            int toplam = x + y;

            Console.WriteLine("Islem tamamlandi");

            return toplam;
        }

        static async Task<string> IslemAsync2()
        {
            return "Selam";
        }

    }

}