//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Composer
//{
//    public class LightNodeIterator : IEnumerator<LightNode>
//    {
//        private readonly Stack<LightNode> nodeStack = new Stack<LightNode>();
//        private LightNode currentNode;

//        public LightNodeIterator(LightNode rootNode)
//        {
//            nodeStack.Push(rootNode);
//        }

//        public LightNode Current => currentNode;

//        object IEnumerator.Current => Current;

//        public bool MoveNext()
//        {
//            if (nodeStack.Count == 0) return false;

//            currentNode = nodeStack.Pop();

//            if (currentNode is LightElementNode elementNode)
//            {
//                int count = elementNode.Children.Count;
//                int index = count - 1;

//                while (index >= 0)
//                {
//                    nodeStack.Push(elementNode.Children[index]);
//                    index--;
//                }
//            }

//            return true;
//        }

//        public void Reset() => throw new NotImplementedException();

//        public void Dispose() { }
//    }
//}
