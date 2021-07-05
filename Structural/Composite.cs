using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.Composite
{
    // A hierarchy of objects, like a tree or a graph.
    
    // Base class of a composition.
    public abstract class Component
    {
        public abstract string Operation();
        
        // IsComposite() function is usually included to indicate if the object can have further children or not.
        // The value "true" means that the two methods below - Add and Remove - are overriden and working too.
        public virtual bool IsComposite()
        {
            return true;
        }

        // These two functions are used to create a composite object. They can, but do not have to be overriden.
        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }
    }

    // An sample end object of a composition.
    public class Leaf : Component
    {
        public override string Operation()
        {
            return "Leaf";
        }

        // IsComposite returns false - the object cannot be made composite. We do not override Add and Remove.
        public override bool IsComposite()
        {
            return false;
        }
    }

    // A different end object of a composition.
    public class CompositeObject : Component
    {
        // This object can be made composite using the List.
        protected List<Component> _children = new List<Component>();

        // We override the Add and Remove methods to create a composite object.
        public void Add(Component component)
        {
            _children.Add(component);
        }

        public void Remove(Component component)
        {
            _children.Remove(component);
        }

        // An operation using one or more child objects.
        public override string Operation()
        {
            int i = 0;
            
            StringBuilder result = new StringBuilder();
            result.Append("Branch: (");

            foreach (var component in _children)
            {
                result.Append(component.Operation());

                if (i != _children.Count - 1)
                {
                    result.Append("+");
                }

                i++;
            }

            result.Append(")");

            return result.ToString();
        }
    }
    
    // An end class.
    public class Client
    {
        // An example of a method that does not work with composite objects - just do operation.
        public void Method1(Component leaf)
        {
            Console.WriteLine(leaf.Operation());
        }
        
        // An example of a method that does work with composite objects - create it, if possible, then do operation.
        public void Method2(Component c1, Component c2)
        {
            if (c1.IsComposite())
            {
                // If we can make the object composite, do it.
                c1.Add(c2);
            }
            
            // Display the result.
            Console.WriteLine(c1.Operation());
        }
    }
    
    // Test the results.
    public class Program
    {
        // Application entry point.
        public static void Mein()
        {
            // Create a worker object.
            var client = new Client();

            // A non-composite object.
            var leaf = new Leaf();
            
            Console.WriteLine("Simple object result:");
            client.Method1(leaf);

            Console.WriteLine();
            
            // A composite object.
            // Create a complex object.
            var tree = new CompositeObject();
            var branch1 = new CompositeObject();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());

            var branch2 = new CompositeObject();
            branch2.Add(new Leaf());
            branch2.Add(new Leaf());
            
            tree.Add(branch1);
            tree.Add(branch2);
            
            Console.WriteLine("Complex object result:");
            client.Method1(tree);
            
            Console.WriteLine("\nMaking the object even more complex:");
            client.Method2(tree, leaf);
        }
    }
}