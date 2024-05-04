
using Composer;
namespace Command
{
    public class AddClassCommand : ICommand
    {
        private readonly LightElementNode node;
        private readonly string cssClass;

        public AddClassCommand(LightElementNode node, string cssClass)
        {
            this.node = node;
            this.cssClass = cssClass;
        }

        // Додавання класу до вузла
        public void Execute()
        {
            node.AddClass(cssClass);
        }

        // Видалення класу з вузла
        public void Undo()
        {
            node.RemoveClass(cssClass);
        }
    }
}
