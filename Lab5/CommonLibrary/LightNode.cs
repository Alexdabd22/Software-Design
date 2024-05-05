
namespace CommonLibrary
{
    public abstract class LightNode
    {
        public ILightNodeState State { get; set; } 

        public void Show() => State.Show(this);
        public void Hide() => State.Hide(this);

        public abstract string OuterHtml(int indentLevel = 0);
    }
}
