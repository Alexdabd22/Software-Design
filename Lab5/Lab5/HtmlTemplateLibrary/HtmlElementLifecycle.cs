using System;


namespace HtmlTemplateLibrary
{
    public abstract class HtmlElementLifecycle
    {
        public void Render()
        {
            OnCreated();
            OnInserted();
            ApplyStyles();
            ApplyClassList();
            OnTextRendered();
            Console.WriteLine("Рендеринг завершено.");
        }

        protected virtual void OnCreated() => Console.WriteLine("Елемент створено.");
        protected virtual void OnInserted() => Console.WriteLine("Елемент вставлено у DOM.");
        protected virtual void ApplyStyles() => Console.WriteLine("Стилі застосовано.");
        protected virtual void ApplyClassList() => Console.WriteLine("Список класів застосовано.");
        protected virtual void OnTextRendered() => Console.WriteLine("Текст відтворено.");
    }
}
