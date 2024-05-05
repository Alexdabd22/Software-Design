using System;
using Composer;

namespace ConsoleVisitor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створення кореневого вузла
            var root = new LightElementNode(new LightElementFlyweight("html"));
            var head = new LightElementNode(new LightElementFlyweight("head"));
            var body = new LightElementNode(new LightElementFlyweight("body"));

            var title = new LightElementNode(new LightElementFlyweight("title"));
            var titleText = new LightTextNode("Демонстрацiя HTML");
            title.AddChild(titleText);
            head.AddChild(title);

            var heading = new LightElementNode(new LightElementFlyweight("h1"));
            var headingText = new LightTextNode("Вiтаємо на сторінці!");
            heading.AddChild(headingText);

            var paragraph1 = new LightElementNode(new LightElementFlyweight("p"));
            var paragraph1Text = new LightTextNode("Це перший абзац на сторiнцi.");
            paragraph1.AddChild(paragraph1Text);

            var paragraph2 = new LightElementNode(new LightElementFlyweight("p"));
            var paragraph2Text = new LightTextNode("Це другий абзац на сторiнцi.");
            paragraph2.AddChild(paragraph2Text);

            body.AddChild(heading);
            body.AddChild(paragraph1);
            body.AddChild(paragraph2);

            root.AddChild(head);
            root.AddChild(body);

            // Створення відвідувача
            var visitor = new HtmlStructureVisitor();

            root.Accept(visitor);

            Console.ReadLine();
        }
    }
}
