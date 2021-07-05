using System.Collections;

namespace DesignPatterns.Behavioral.Iterator
{
	// Sequentially access the elements of a collection.

	// Defines an interface for traversing a collection of items.
	public interface IIterator
	{
		object First { get; }
		object Next { get; }
		bool IsDone();
		object CurrentItem();
	}

	// Implements the iterator, keeps track of current position inside the collection.
	public class ConcreteIterator : IIterator
	{
		// Collection which we iterate through.
		private ConcreteAggregate _aggregate;
		private int _current = 0;

		public ConcreteIterator(ConcreteAggregate aggregate)
		{
			_aggregate = aggregate;
		}

		// Get the first object of the sentence.
		public object First
		{
			get
			{
				return _aggregate[0];
			}
		}

		// Get the next object of the sentence, increment _current so that we can keep track of the current position.
		public object Next
		{
			get
			{
				object next = null;
				if (_current < _aggregate.Count - 1)
				{
					next = _aggregate[++_current];
				}

				return next;
			}
		}

		// Returns true if the current index is still inside the collection, false otherwise.
		public bool IsDone()
		{
			return _current >= _aggregate.Count;
		}

		// Returns the current item.
		public object CurrentItem()
		{
			return _aggregate[_current];
		}
	}

	// Defines the creation of an Iterator object.
	public abstract class Aggregate
	{
		public abstract IIterator CreateIterator();
	}

	// Returns the right ConcreteIterator object and provides the collection to iterate over.
	public class ConcreteAggregate : Aggregate
	{
		// This can be any collection that is indexed using [].
		private ArrayList _items = new ArrayList();

		public override IIterator CreateIterator()
		{
			return new ConcreteIterator(this);
		}

		// Get the collection's count.
		public int Count
		{
			get
			{
				return _items.Count;
			}
		}

		// Indexer.
		public object this[int index]
		{
			get
			{
				return _items[index];
			}
			set
			{
				_items.Insert(index, value);
			}
		}
	}

	public class Client
	{
		public void Create()
		{
			var a = new ConcreteAggregate();
			a[0] = "Item 1";
			a[1] = "Item 2";
			a[2] = "Item 3";
			a[3] = "Item 4";

			var iterator = a.CreateIterator();

			// Iterate over the collection.

			object item = iterator.First;

			while (item != null)
			{
				// Do something.
				// ..

				item = iterator.Next;
			}
		}
	}
}
