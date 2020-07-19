using System.Collections.Generic;

namespace DesignPatterns.Creational
{
	// Separates object construction from its representation
	// This pattern requires 4 classes: Builder, ConcreteBuilder, Director and Product

	// Builder is an abstract class that specifies parts of a Product object
	// Note that the Builder could also be an interface, which allows more flexibility
	public abstract class Builder
	{
		public abstract void BuildPartA();
		public abstract void BuildPartB();
		public abstract Product GetResult();
	}

	// ConcreteBuilder1 overrides the Builder class method and creates specific parts of the product
	public class ConcreteBuilder1 : Builder
	{
		private Product _product = new Product();

		public override void BuildPartA()
		{
			// Assemble a part
			_product.Add("A");
		}

		public override void BuildPartB()
		{
			// Assemble a part
			_product.Add("B");
		}

		public override Product GetResult()
		{
			// Return the completed product
			return _product;
		}
	}

	// ConcreteBuilder2 can create different parts, or even a different product
	public class ConcreteBuilder2 : Builder
	{
		private Product _product = new Product();

		public override void BuildPartA()
		{
			// Assemble a different part
			_product.Add("A different A");
		}

		public override void BuildPartB()
		{
			// Assemble a different part
			_product.Add("A different B");
		}

		public override Product GetResult()
		{
			// Return the completed product
			return _product;
		}
	}

	// Director is the class that actually constructs objects using the Builder class / interface
	public class Director
	{
		public void Construct(Builder builder)
		{
			// Take any class that implements Builder and build the product
			builder.BuildPartA();
			builder.BuildPartB();
		}
	}

	// Product is the complex object that gets assembled by ConcreteBuilder
	public class Product
	{
		// In this example, parts of the product will be a List, but they can be much more than that
		private List<string> _parts = new List<string>();

		public void Add(string part)
		{
			_parts.Add(part);
		}

		public void Show()
		{
			// Show off those parts here
		}
	}
}
