namespace Composer
{
    public class LightTextNode : LightNode
    {
        public string Text { get; private set; }

        public LightTextNode(string text)
        {
            Text = text;
        }

        public override string OuterHtml(int indentLevel = 0)
        {
            string indent = new string(' ', indentLevel * 4);
            return $"{indent}{Text}\n";
        }

        public void SetText(string newText)
        {
            Text = newText;
        }
    }
}
