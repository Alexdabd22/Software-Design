using System.Collections.Generic;

namespace TicTacToeGame.Observer
{
    public class Subject : ISubject
    {
        private readonly List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify(string propertyName)
        {
            foreach (var observer in observers)
            {
                observer.Update(propertyName);
            }
        }
    }
}

