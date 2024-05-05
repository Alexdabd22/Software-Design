using System;

namespace TemplateMethod
{
    public class CustomDivElementLifecycle : CommonLibrary.HtmlElementLifecycle
    {
        public override void OnCreated() => Console.WriteLine("Див створено.");
        public override void ApplyStyles() => Console.WriteLine("Див стилiзовано особливим чином.");
    }
}
