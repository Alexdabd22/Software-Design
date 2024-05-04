using System;


namespace HtmlTemplateLibrary
{
    public class CustomDivElementLifecycle : HtmlElementLifecycle
    {
        protected override void OnCreated() => Console.WriteLine("Див створено.");
        protected override void ApplyStyles() => Console.WriteLine("Див стилізовано особливим чином.");
    }
}
