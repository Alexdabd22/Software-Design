
namespace CommonLibrary
{
    public abstract class LightNode : IElementNode, ITextNode
    {
        public ILightNodeState State { get; set; }

        public abstract void Accept(ILightNodeVisitor visitor);
        public abstract string OuterHtml(int indentLevel = 0);
    }

    public interface IElementNode
    {
        void Accept(ILightNodeVisitor visitor);
    }

    public interface ITextNode
    {
        void Accept(ILightNodeVisitor visitor);
    }
}
