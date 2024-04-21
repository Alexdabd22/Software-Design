using System;


namespace ChainOfResponsibilityLibrary
{
    public class UltimateSupportHandler : SupportHandler
    {
        public override void HandleRequest(UserRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request), "Request cannot be null");

            if (request.Level == 4)
            {
                Console.WriteLine("Ultimate support is handling the request.");
            }
            else
            {
                Console.WriteLine("The request could not be handled. Please try again.");
            }
        }
    }
}
