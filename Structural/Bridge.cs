namespace DesignPatterns.Structural.Bridge
{
	// Separates an object’s interface from its implementation.

	// Connects with the abstract Implementor.
	public class Abstraction
	{
		// Limited access.
		public Implementor Implementor { protected get; set; }

		public virtual void Operation()
		{
			Implementor.Operation();
		}
	}

	// Provides primitive operations for implementation classes.
	public abstract class Implementor
	{
		public abstract void Operation();
	}

	// Extends Abstraction, including some additional functionality.
	public class RefinedAbstraction : Abstraction
	{
		public override void Operation()
		{
			base.Operation();

			// Do something else here
		}
	}

	// Defines core operation of the implementor.
	public class ConcreteImplementorA : Implementor
	{
		public override void Operation()
		{
			// Do something here
		}
	}

	// Defines a different core operation of the implementor.
	public class ConcreteImplementorB : Implementor
	{
		public override void Operation()
		{
			// Do something else here.
		}
	}

	public class Client
	{
		public static void Create()
		{
			var ab = new RefinedAbstraction();

			// Set initial implementation.
			ab.Implementor = new ConcreteImplementorA();
			ab.Operation();

			// Replace the implementation with a different one (within the same object).
			ab.Implementor = new ConcreteImplementorB();
			ab.Operation();
		}
	}
}
