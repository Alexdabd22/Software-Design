using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverLibrary
{
    public class LightElementFlyweight
    {
        public string TagName { get; }
        public string DisplayType { get; }

        public LightElementFlyweight(string tagName, string displayType)
        {
            TagName = tagName;
            DisplayType = displayType;
        }
    }
}
