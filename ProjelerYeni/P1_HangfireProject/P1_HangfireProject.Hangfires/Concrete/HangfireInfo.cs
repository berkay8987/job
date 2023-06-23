using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_HangfireProject.Hangfires.Abstract;

namespace P1_HangfireProject.Hangfires.Concrete
{
    public class HangfireInfo : IHangfireInfo
    {
        public void HangfireStartText()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("Hangfire Started");
            Console.WriteLine("********************************");
        }

        public void HangfireEndText()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("Hangfire Ended");
            Console.WriteLine("********************************");
        }

        public void HangfireNoChangeText()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("\nNo member(s) were effected.\n");
            Console.WriteLine("********************************");
        }
    }
}
