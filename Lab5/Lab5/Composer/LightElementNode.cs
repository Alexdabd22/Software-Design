using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections;

namespace Composer
{
    public class LightElementNode : LightNode, IEnumerable<LightNode>
    {
        public LightElementFlyweight Flyweight { get; }
        public bool IsSelfClosing { get; }
        private List<string> cssClasses;
        public List<LightNode> Children { get; }

        public LightElementNode(LightElementFlyweight flyweight, bool isSelfClosing = false, IEnumerable<string> cssClasses = null, IEnumerable<LightNode> children = null)
        {
            Flyweight = flyweight;
            IsSelfClosing = isSelfClosing;
            this.cssClasses = new List<string>(cssClasses ?? Enumerable.Empty<string>());
            Children = new List<LightNode>(children ?? Enumerable.Empty<LightNode>());
        }

        public void AddChild(LightNode child)
        {
            if (IsSelfClosing)
            {
                throw new InvalidOperationException($"{Flyweight.TagName} is a self-closing tag and cannot contain children.");
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

        public override string OuterHtml(int indentLevel = 0)
        {
            var sb = new StringBuilder();
            RenderHtml(sb, indentLevel);
            return sb.ToString();
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
