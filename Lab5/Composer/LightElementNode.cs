using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibrary;
using State;


namespace Composer
{
    public class LightElementNode : LightNode, IEnumerable<LightNode>
    {
        public string TagName { get; }
        public LightElementFlyweight Flyweight { get; }
        public bool IsSelfClosing { get; }
        private List<string> cssClasses;
        public List<LightNode> Children { get; }

        public ILightNodeState NodeState { get; set; } = new VisibleState();

        public LightElementNode(LightElementFlyweight flyweight, bool isSelfClosing = false, IEnumerable<string> cssClasses = null, IEnumerable<LightNode> children = null)
        {
            Flyweight = flyweight;
            TagName = Flyweight.TagName;
            IsSelfClosing = isSelfClosing;
            this.cssClasses = new List<string>(cssClasses ?? Enumerable.Empty<string>());
            Children = new List<LightNode>(children ?? Enumerable.Empty<LightNode>());
        }

        public void AddChild(LightNode child)
        {
            if (IsSelfClosing)
            {
                throw new InvalidOperationException($"{Flyweight.TagName} є самозакриваючим тегом i не може мiстити дочiрнiх елементiв.");
            }
            Children.Add(child);
        }
        // Додавання CSS-класу
        public void AddClass(string cssClass)
        {
            if (!string.IsNullOrWhiteSpace(cssClass) && !cssClasses.Contains(cssClass))
            {
                cssClasses.Add(cssClass);
            }
        }
        // Видалення CSS-класу
        public void RemoveClass(string cssClass)
        {
            cssClasses.Remove(cssClass);
        }

        public override void Accept(ILightNodeVisitor visitor)
        {
            visitor.VisitElementNode(this);

            foreach (var child in Children)
            {
                child.Accept(visitor);
            }
        }

        public override string OuterHtml(int indentLevel = 0)
        {
            var sb = new StringBuilder();
            RenderHtml(sb, indentLevel);
            return sb.ToString();
        }

        private void RenderHtml(StringBuilder sb, int indentLevel)
        {
            string indent = new string(' ', indentLevel * 4);
            sb.Append($"{indent}<{Flyweight.TagName}");

            if (cssClasses.Any())
            {
                sb.Append($" class=\"{string.Join(" ", cssClasses)}\"");
            }

            if (IsSelfClosing)
            {
                sb.AppendLine(" />");
            }
            else
            {
                sb.AppendLine(">");
                sb.Append(InnerHtml(indentLevel + 1));
                sb.AppendLine($"{indent}</{Flyweight.TagName}>");
            }
        }

        public string InnerHtml(int indentLevel = 0)
        {
            if (IsSelfClosing) return "";

            var sb = new StringBuilder();
            foreach (var child in Children)
            {
                sb.Append(child.OuterHtml(indentLevel + 1));
            }
            return sb.ToString();
        }
        public void Hide()
        {
            NodeState.Hide(this);
        }

        public void Show()
        {
            NodeState.Show(this);
        }
        public IEnumerator<LightNode> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
