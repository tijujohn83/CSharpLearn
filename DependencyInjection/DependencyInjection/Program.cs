using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientA clientA = new ClientA(new Service());
            clientA.Start();

            ClientB clientB = new ClientB();
            clientB.Service = new Service();
            clientB.Start();

            ClientC clientC = new ClientC();            
            clientC.Start(new Service());
        }
    }

    class Service : IService
    {
        public void Serve()
        {
            Console.WriteLine("Service call...");
        }
    }

}
