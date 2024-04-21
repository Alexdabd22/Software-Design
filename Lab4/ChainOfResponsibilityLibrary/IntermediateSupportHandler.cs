using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityLibrary
{
    public class IntermediateSupportHandler : SupportHandler
    {
        public override void HandleRequest(UserRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request), "Request cannot be null");

            if (request.Level == 2)
            {
                Console.WriteLine("Intermediate support is handling the request.");
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("No successor to handle the request.");
            }
        }
    }
}
