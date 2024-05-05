using CommonLibrary;
namespace Composer

{
    public class LightTextNode : LightNode
    {
        public string Text { get; private set; }

        public LightTextNode(string text)
        {
            Text = text;
        }

        public void SetText(string newText)
        {
            Text = newText;
        }

        public override void Accept(ILightNodeVisitor visitor)
        {
            visitor.VisitTextNode(this);
        }

        public override string OuterHtml(int indentLevel = 0)
        {
            string indent = new string(' ', indentLevel * 4);
            return $"{indent}{Text}\n";
        }
    }
}
