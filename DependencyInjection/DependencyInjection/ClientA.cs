using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DependencyInjection
{
    class ClientA
    {
        IService _service;

        public ClientA(IService service)
        {
            this._service = service;
        }

        public void Start()
        {
            Console.WriteLine("Client A service started..");
            _service.Serve();
        }
    }
}
