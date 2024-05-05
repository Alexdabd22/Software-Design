using System;


namespace TemplateMethod
{
    public class CustomSpanElementLifecycle : CommonLibrary.HtmlElementLifecycle
    {
        public override void OnCreated() => Console.WriteLine("Спан створено.");
        public override void ApplyClassList() => Console.WriteLine("Спан отримав клас 'highlight'.");
    }
}
