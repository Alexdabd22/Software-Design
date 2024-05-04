using System;

namespace HtmlTemplateLibrary
{
    public class CustomSpanElementLifecycle : HtmlElementLifecycle
    {
        protected override void OnCreated() => Console.WriteLine("Спан створено.");
        protected override void ApplyClassList() => Console.WriteLine("Спан отримав клас 'highlight'.");
    }
}
