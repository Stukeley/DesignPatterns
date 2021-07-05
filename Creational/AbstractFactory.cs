namespace DesignPatterns.Creational.AbstractFactory
{
	// Creates an instance of several families of classes.

	// Specifies parts of an *abstract* Product object.
	public abstract class AbstractFactory
	{
		public abstract AbstractProductA CreateProductA();
		public abstract AbstractProductB CreateProductB();
	}

	// Implements the AbstractFactory's methods.
	public class ConcreteFactory1 : AbstractFactory
	{
		public override AbstractProductA CreateProductA()
		{
			return new ProductA1();
		}

		public override AbstractProductB CreateProductB()
		{
			return new ProductB1();
		}
	}

	// Implements the AbstractFactory's methods, but differently.
	public class ConcreteFactory2 : AbstractFactory
	{
		public override AbstractProductA CreateProductA()
		{
			return new ProductA2();
		}

		public override AbstractProductB CreateProductB()
		{
			return new ProductB2();
		}
	}

	// Declares an interface for a type of product object.
	public abstract class AbstractProductA
	{
		// Create parts of the product.
	}

	// Declares an interface for a type of product object.
	public abstract class AbstractProductB
	{
		public abstract void Interact(AbstractProductA a);
	}

	// The actual product A.
	public class ProductA1 : AbstractProductA
	{
		// Implement part of the product.
	}

	// A different product A.
	public class ProductA2 : AbstractProductA
	{
		// Implement part of the product.
	}

	// The actual product B.
	public class ProductB1 : AbstractProductB
	{
		public override void Interact(AbstractProductA a)
		{
			// Do something.
		}
	}

	// A different product B.
	public class ProductB2 : AbstractProductB
	{
		public override void Interact(AbstractProductA a)
		{
			// Do something else.
		}
	}

	// Uses the abstract classes / interfaces to actually create products and operate on them.
	public class Client
	{
		private AbstractProductA _productA;
		private AbstractProductB _productB;

		// Pass the abstract factory to create products.
		public Client(AbstractFactory factory)
		{
			_productA = factory.CreateProductA();
			_productB = factory.CreateProductB();
		}

		// Make the products interact.
		public void Run()
		{
			_productB.Interact(_productA);
		}
	}
}
