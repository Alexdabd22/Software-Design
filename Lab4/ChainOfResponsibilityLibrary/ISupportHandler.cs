

namespace ChainOfResponsibilityLibrary
{
    public interface ISupportHandler
    {
        void SetSuccessor(ISupportHandler successor);
        void HandleRequest(UserRequest request);
    }
}
