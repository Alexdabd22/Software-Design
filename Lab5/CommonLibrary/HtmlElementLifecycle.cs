using System;
namespace CommonLibrary
{
    public abstract class HtmlElementLifecycle
    {
        // Шаблонний метод рендерингу
        public void Render()
        {
            OnCreated();
            OnInserted();
            ApplyStyles();
            ApplyClassList();
            OnTextRendered();
            Console.WriteLine("Рендеринг завершено.");
        }

        public virtual void OnCreated() => Console.WriteLine("Елемент створено.");
        public virtual void OnInserted() => Console.WriteLine("Елемент вставлено у DOM.");
        public virtual void ApplyStyles() => Console.WriteLine("Стилі застосовано.");
        public virtual void ApplyClassList() => Console.WriteLine("Список класів застосовано.");
        public virtual void OnTextRendered() => Console.WriteLine("Текст відтворено.");
    }
}
