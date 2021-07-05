using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Behavioral.Memento
{
    // Making a snapshot of an object that can be restored in the future.

    // Interface containing methods used by Concrete Mementoes.
    public interface IMemento
    {
        string GetName();
        string GetState();
        DateTime GetDate();
    }
    
    // Implements methods for restoring an object's state.
    public class ConcreteMemento: IMemento
    {
        private string _state;
        private DateTime _date;

        public ConcreteMemento(string state)
        {
            _state = state;
            _date = DateTime.Now;
        }

        public string GetName()
        {
            return _date.ToString() + " - " + _state;
        }

        public string GetState()
        {
            return _state;
        }

        public DateTime GetDate()
        {
            return _date;
        }
    }

    // The class which State can change over time. This is the class which State we want to preserve.
    public class Originator
    {
        private string _state;

        public Originator(string state)
        {
            _state = state;
        }

        public void DoSomething()
        {
            Console.WriteLine("Changing state!");
            
            // Randomize character order in state.
            _state = _state.ToCharArray().OrderBy(x => Guid.NewGuid()).ToString();
            
            Console.WriteLine($"New state is: {_state}");
        }

        // Save the current state.
        public IMemento Save()
        {
            return new ConcreteMemento(_state);
        }

        // Restore a previous state.
        public void Restore(IMemento memento)
        {
            _state = memento.GetState();
        }
    }

    // A class responsible for storing Mementoes.
    public class Caretaker
    {
        private List<IMemento> _mementoes = new List<IMemento>();

        private Originator _originator = null;

        public Caretaker(Originator originator)
        {
            _originator = originator;
        }
        
        // Create a memento and store it.
        public void Backup()
        {
            _mementoes.Add(_originator.Save());
        }

        // Order to restore a previous state.
        public void Undo()
        {
            if (_mementoes.Count == 0)
            {
                return;
            }

            var memento = _mementoes.Last();
            _mementoes.Remove(memento);

            try
            {
                _originator.Restore(memento);
            }
            catch (Exception e)
            {
                // If an exception occurs, try again with the next memento.
                Console.WriteLine(e);
                Undo();
            }
        }

        // Show history of backups.
        public void ShowHistory()
        {
            foreach (var memento in _mementoes)
            {
                Console.WriteLine(memento.GetName());
            }
        }
    }
    
    // Test the results.
    public class Program
    {
        public static void Mein()
        {
            var originator = new Originator("Hello world!");
            var caretaker = new Caretaker(originator);
            
            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            Console.WriteLine();
            caretaker.ShowHistory();
            
            // Undo the changes.
            caretaker.Undo();
            caretaker.ShowHistory();
            
            caretaker.Undo();
            caretaker.Undo();
        }
    }
}