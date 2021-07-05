namespace DesignPatterns.Structural.Decorator
{
	// Add responsibilities to objects dynamically.

	// Maintains a reference to a Component object and defines an interface that conforms to Component's interface.
	public class Decorator : Component
	{
		public Component Component { protected get; set; }

		// Operate on the Compontnt.
		public override void Operation()
		{
			if (!(Component is null))
			{
				Component.Operation();
			}
		}
	}

	// Provides an interface for objects that can have responsibility added to them dynamically.
	public abstract class Component
	{
		public abstract void Operation();
	}

	// Defines an actual object that can have responsibility added to it dynamically.
	public class ConcreteComponent : Component
	{
		public override void Operation()
		{
			// Do something here
		}
	}

	// Adds responsibility to the Component (defined in Decorator).
	public class ConcreteDecoratorA : Decorator
	{
		public override void Operation()
		{
			base.Operation();

			// Do something extra
		}
	}

	// Adds different responsibility to the Component (defined in Decorator).
	public class ConcreteDecoratorB : Decorator
	{
		public override void Operation()
		{
			base.Operation();

			// Add behavior.

			AddBehavior();
			// Do something extra.
		}

		public void AddBehavior()
		{
			// Do something here.
		}
	}

	public class Client
	{
		public static void Create()
		{
			var c = new ConcreteComponent();
			var d1 = new ConcreteDecoratorA();
			var d2 = new ConcreteDecoratorB();

			// Link decorators.
			d1.Component = c;
			d2.Component = d1;

			// Do the operation.

			d2.Operation();
		}
	}
}
