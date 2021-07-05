namespace DesignPatterns.Creational.Prototype
{
	// A fully initialized instance to be copied or cloned.

	// The prototype class declares functionality needed for cloning itself.
	public abstract class Prototype
	{
		public string Id { get; }

		public Prototype(string id)
		{
			Id = id;
		}

		public abstract Prototype Clone();
	}

	// Implements the operation to clone itself.
	public class ConcretePrototype1 : Prototype
	{
		public ConcretePrototype1(string id) : base(id)
		{
		}

		// Returns a shallow copy of this object.
		public override Prototype Clone()
		{
			return (Prototype)this.MemberwiseClone();
		}
	}

	// Implements the operation to clone itself - but is a different object, eg. different properties.
	public class ConcretePrototype2 : Prototype
	{
		public int Something { get; }

		public ConcretePrototype2(string id, int something) : base(id)
		{
			Something = something;
		}

		// Returns a shallow copy of this object.
		public override Prototype Clone()
		{
			return (Prototype)this.MemberwiseClone();
		}
	}

	// Creates new objects by cloning existing ones.
	public class Client
	{
		public void Create()
		{
			var p1 = new ConcretePrototype1("1");
			var p2 = new ConcretePrototype2("2", 123);

			// Clone the objects.
			var c1 = p1.Clone();
			var c2 = p2.Clone();
		}
	}
}
