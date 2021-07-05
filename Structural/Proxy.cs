namespace DesignPatterns.Structural.Proxy
{
	// An object representing another object.

	// Maintains a reference to the original object, controls access to it and can create, delete or modify it.
	public class Proxy : Subject
	{
		private RealSubject _realSubject;

		public override void Request()
		{
			// Check if the object exists first.
			if (_realSubject is null)
			{
				_realSubject = new RealSubject();
			}

			// Authenticate the request.
			// ...

			// If succeeded, let the request through.
			_realSubject.Request();
		}
	}

	public abstract class Subject
	{
		public abstract void Request();
	}

	public class RealSubject : Subject
	{
		public override void Request()
		{
			// Do something here.
		}
	}

	public class Client
	{
		public void Create()
		{
			var p = new Proxy();

			// Request a service.
			p.Request();
		}
	}
}
