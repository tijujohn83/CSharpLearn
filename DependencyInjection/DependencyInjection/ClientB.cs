using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DependencyInjection
{
    class ClientB
    {
        IService _service;

        public IService Service
        {
            set
            {
                this._service = value; 
            }
        }

        public void Start()
        {
            Console.WriteLine("Client B service started..");
            this._service.Serve();
        }

    }
}
