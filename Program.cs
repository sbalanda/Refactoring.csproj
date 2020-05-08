using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactoring
{
    class Program
    {
        public static void Main(string[] args)
        {
            RemoteController remoteController = new RemoteController();
            while (true)
            {
                string output = remoteController.Call(Console.ReadLine());
                Console.WriteLine(output);
            }

            Console.ReadLine();
        }
    }
}
