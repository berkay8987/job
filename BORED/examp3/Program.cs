using System;
using System.Diagnostics;

namespace examp3
{
    class Program
    {
        static async void Main(string[] args)
        {
            MyScript mc = new MyScript();
            await mc.InitiateAsyncVersion();
        }

    }
}