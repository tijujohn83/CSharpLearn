using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DependencyInjection
{
    class ClientC
    {
        IService _service;

        public void Start(IService service)
        {
            this._service = service;
            Console.WriteLine("Service started from Client C...");
            this._service.Serve();
        }
    }
}
