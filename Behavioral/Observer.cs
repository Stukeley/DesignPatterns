using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Observer
{
	// A way of notifying change to a number of classes.

	// Defines an interface for objects that should be noted of changes in a subject.
	public abstract class Observer
	{
		public abstract void Update();
	}

	// Maintains a reference to a ConcreteSubject object, stores a state (that should be consistent with the subject's) and updates it to keep it consistent.
	public class ConcreteObserver : Observer
	{
		// Identify the observer.
		private string _name;

		// The current state of the subject (in this case a string).
		private string _observerState;

		// The subject that is being watched.
		public ConcreteSubject Subject { get; set; }

		public ConcreteObserver(ConcreteSubject subject, string name)
		{
			Subject = subject;
			_name = name;
		}

		// Update the object's state and notify observers about the change.
		public override void Update()
		{
			_observerState = Subject.SubjectState;

			// Do something more here
		}
	}

	// Allows attaching and detaching Observer objects, and knows its observers (there can be any number of them).
	public abstract class Subject
	{
		private List<Observer> _observers = new List<Observer>();

		// Attach a new observer.
		public void Attach(Observer observer)
		{
			_observers.Add(observer);
		}

		// Remove an observer from the list.
		public void Detach(Observer observer)
		{
			_observers.Remove(observer);
		}

		public void Notify()
		{
			foreach (var o in _observers)
			{
				o.Update();
			}
		}
	}

	// Sends notification to its observers when its state changes.
	public class ConcreteSubject : Subject
	{
		public string SubjectState { get; set; }
	}

	public class Client
	{
		public void Create()
		{
			var s = new ConcreteSubject();

			// Create 3 observers that watch over the subject.

			s.Attach(new ConcreteObserver(s, "X"));
			s.Attach(new ConcreteObserver(s, "Y"));
			s.Attach(new ConcreteObserver(s, "Z"));

			s.SubjectState = "New state";
			// Notify the observers, updating their state.
			s.Notify();
		}
	}
}
