using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComposerClassLibrary;

namespace LightweightClassLibrary
{
    public static class HTMLConverter
    {
        public static LightElementNode ConvertTextToHtml(string[] lines)
        {
            var rootElement = new LightElementNode("div");
            ProcessLines(lines, rootElement, (tagName, line) => CreateElementNode(tagName, line));
            return rootElement;
        }

        public static LightElementNode ConvertTextToHtmlUsingFlyweight(string[] lines, LightElementFactory factory)
        {
            var rootElement = factory.GetLightElementNode("div", "block", false);
            ProcessLines(lines, rootElement, (tagName, line) => factory.GetLightElementNode(tagName, "block", false, line));
            return rootElement;
        }

        private static void ProcessLines(string[] lines, LightElementNode rootElement, Func<string, string, LightElementNode> createElementNodeFunc)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                string tagName = DetermineTagName(line, i);
                LightElementNode elementNode = createElementNodeFunc(tagName, line);
                rootElement.AddChild(elementNode);
            }
        }

        private static string DetermineTagName(string line, int index)
        {
            if (index == 0) return "h1";
            if (line.Length < 20) return "h2";
            if (line.StartsWith(" ")) return "blockquote";
            return "p";
        }

        private static LightElementNode CreateElementNode(string tagName, string line)
        {
            var elementNode = new LightElementNode(tagName, "block", false);
            elementNode.AddChild(new LightTextNode(line));
            return elementNode;
        }
    }
}

