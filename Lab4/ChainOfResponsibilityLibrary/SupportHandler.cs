using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityLibrary
{
    public abstract class SupportHandler : ISupportHandler
    {
        protected ISupportHandler successor;

        public void SetSuccessor(ISupportHandler successor)
        {
            this.successor = successor ?? throw new ArgumentNullException(nameof(successor), "Successor cannot be null");
        }

        public abstract void HandleRequest(UserRequest request);
    }
}
