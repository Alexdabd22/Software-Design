using ComposerClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightweightClassLibrary
{
    public class LightElementFactory
    {
        private readonly Dictionary<string, LightElementNode> _flyweightPool = new Dictionary<string, LightElementNode>();

        public LightElementNode GetLightElementNode(string tagName, string displayType, bool isSelfClosing, string textContent = "")
        {
            string key = $"{tagName}:{displayType}:{isSelfClosing}:{textContent}";

            if (!_flyweightPool.TryGetValue(key, out var elementNode))
            {
                elementNode = new LightElementNode(tagName, displayType, isSelfClosing);
                if (!string.IsNullOrWhiteSpace(textContent))
                {
                    elementNode.AddChild(new LightTextNode(textContent));
                }
                _flyweightPool.Add(key, elementNode);
            }

            return elementNode;
        }
    }
}
