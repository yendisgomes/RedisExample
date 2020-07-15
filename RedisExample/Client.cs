using System;
using System.Collections.Generic;
using System.Text;

namespace RedisExample
{
    public class Client
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Client()
        {
            this.Key = Guid.NewGuid();
        }
    }
}
