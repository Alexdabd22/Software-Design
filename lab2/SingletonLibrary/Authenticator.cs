using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonLibrary
{
    public sealed class Authenticator
    {
        private static readonly Lazy<Authenticator> lazyInstance =
            new Lazy<Authenticator>(() => new Authenticator());

        public static Authenticator Instance => lazyInstance.Value;

        private Authenticator()
        {
        }

        
        public void Authenticate()
        {
            Console.WriteLine("Authenticating...");
        }
    }


}
