namespace DesignPatterns.Structural.Facade
{
	// A single class that represents an entire subsystem (classes working in a defined, synchronized manner).

	// Facade knows which subsystem classes make a request, and directs them to appropriate subsystem objects.
	public class Facade
	{
		private SubsystemOne _one;
		private SubsystemTwo _two;
		private SubsystemThree _three;
		private SubsystemFour _four;

		// Implement the subsystems.
		public Facade()
		{
			_one = new SubsystemOne();
			_two = new SubsystemTwo();
			_three = new SubsystemThree();
			_four = new SubsystemFour();
		}

		// Do something with (some of the) subsystems.
		public void MethodA()
		{
			_one.MethodOne();
			_two.MethodTwo();
			_four.MethodFour();
		}

		// Do something different.
		public void MethodB()
		{
			_two.MethodTwo();
			_three.MethodThree();
		}
	}

	// Subsystem classes implement functionality and handle the work assigned by Facade (but don't know about its existence).

	public class SubsystemOne
	{
		public void MethodOne()
		{
			// Do something here.
		}
	}

	public class SubsystemTwo
	{
		public void MethodTwo()
		{
			// Do something here.
		}
	}

	public class SubsystemThree
	{
		public void MethodThree()
		{
			// Do something here.
		}
	}

	public class SubsystemFour
	{
		public void MethodFour()
		{
			// Do something here.
		}
	}

	public class Client
	{
		public void Create()
		{
			// Create only the facade - no need to create subsystem objects, Facade keeps track of them.
			var facade = new Facade();

			// Call the methods.

			facade.MethodA();
			facade.MethodB();
		}
	}
}
