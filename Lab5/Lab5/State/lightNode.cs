using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public abstract class LightNode
    {
        public ILightNodeState State { get; set; } = new VisibleState();

        public void Show() => State.Show(this);
        public void Hide() => State.Hide(this);
        public void Select() => State.Select(this);
        public void Deselect() => State.Deselect(this);
        public abstract string OuterHtml(int indentLevel = 0);
    }
}
