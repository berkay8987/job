using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examp3
{
    public class MyScript
    {
        public void InitiateSyncVersion()
        {
            var sw = Stopwatch.StartNew();

            YumurtalariKir();
            YumurtalariCirp();
            TuzEkle();
            OcagiAc();
            TavayiIsit();
            YagiDok();
            YumurtayiEkle();
            Pisir();
            ServisEt();

            sw.Stop();
            Console.WriteLine($"Time Elapsed: {sw.ElapsedMilliseconds} ms.");
        }

        public async Task InitiateAsyncVersion()
        {
            var sw = Stopwatch.StartNew();

            await YumurtalariKirAsync();
            await YumurtalariCirpAsync();
            await TuzEkleAsync();
            await OcagiAcAsync();
            await TavayiIsitAsync();
            await YagiDokAsync();
            await YumurtayiEkleAsync();
            await PisirAsync();
            await ServisEtAsync();

            sw.Stop();
            Console.WriteLine($"Time Elapsed: {sw.ElapsedMilliseconds} ms.");
        }

        #region AsyncVersion
        public async Task YumurtalariKirAsync()
        {
            await Task.Delay(500);
            Console.WriteLine("Yumurtalar Kirildi.");
        }

        public async Task YumurtalariCirpAsync()
        {
            await Task.Delay(750);
            Console.WriteLine("Yumurtalar Cirpildi.");
        }

        public async Task TuzEkleAsync()
        {
            await Task.Delay(250);
            Console.WriteLine("Tuz Eklendi.");
        }

        public async Task OcagiAcAsync()
        {
            await Task.Delay(500);
            Console.WriteLine("Ocak Acildi.");
        }

        public async Task TavayiIsitAsync()
        {
            await Task.Delay(2000);
            Console.WriteLine("Tava Isindi.");
        }

        public async Task YagiDokAsync()
        {
            await Task.Delay(500);
            Console.WriteLine("Yag Dokuldu.");
        }

        public async Task YumurtayiEkleAsync()
        {
            await Task.Delay(500);
            Console.WriteLine("Yumurta Eklendi.");
        }

        public async Task PisirAsync()
        {
            await Task.Delay(2000);
            Console.WriteLine("Pisirildi.");
        }

        public async Task ServisEtAsync()
        {
            await Task.Delay(500);
            Console.WriteLine("Servis Edildi.");
        }
        #endregion

        #region SyncVersion

        public void YumurtalariKir()
        {
            Task.Delay(500).Wait();
            Console.WriteLine("Yumurtalar Kirildi.");
        }

        public void YumurtalariCirp()
        {
            Task.Delay(750).Wait();
            Console.WriteLine("Yumurtalar Cirpildi.");
        }

        public void TuzEkle()
        {
            Task.Delay(250).Wait();
            Console.WriteLine("Tuz Eklendi.");
        }

        public void OcagiAc()
        {
            Task.Delay(500).Wait();
            Console.WriteLine("Ocak Acildi.");
        }

        public void TavayiIsit()
        {
            Task.Delay(2000).Wait();
            Console.WriteLine("Tava Isindi.");
        }

        public void YagiDok()
        {
            Task.Delay(500).Wait();
            Console.WriteLine("Yag Dokuldu.");
        }

        public void YumurtayiEkle()
        {
            Task.Delay(500).Wait();
            Console.WriteLine("Yumurta Eklendi.");
        }

        public void Pisir()
        {
            Task.Delay(2000).Wait();
            Console.WriteLine("Pisirildi.");
        }

        public void ServisEt()
        {
            Task.Delay(500).Wait();
            Console.WriteLine("Servis Edildi.");
        }

        #endregion
    }
}
