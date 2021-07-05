using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.ChainOfResponsibility
{
    // Passing a request along a chain of handlers until one of them takes care of the request.
    
    // An interface - base for handler classes.
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        
        object Handle(object request);
    }

    // An abstract class implementing the interface, setting base for the handler classes.
    public abstract class Handler : IHandler
    {
        // Next handler in chain.
        private IHandler _nextHandler;
        
        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            
            // Returning the handler helps us link them together.
            return _nextHandler;
        }

        // This method is used to pass the request to the next handler - if it exists.
        public virtual object Handle(object request)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }

    // Concrete handlers. The implementation of SetNext stays the same.
    public class IntHandler : Handler
    {
        public override object Handle(object request)
        {
            // Consider the request handled if it's an int.
            if (request is int i)
            {
                return $"Request handled! It was an int. Value: {i}";
            }
            // Otherwise, pass the request to the next handler.
            else
            {
                return base.Handle(request);
            }
        }
    }

    public class DoubleHandler : Handler
    {
        public override object Handle(object request)
        {
            // Consider the request handled if it's a double.
            if (request is double d)
            {
                return $"Request handled! It was a double. Value: {d}";
            }
            // Otherwise, pass the request to the next handler.
            else
            {
                return base.Handle(request);
            }
        }
    }

    public class StringHandler : Handler
    {
        public override object Handle(object request)
        {
            // Consider the request handled if it's a string.
            if (request is string s)
            {
                return $"Request handled! It was a string. Value: {s}";
            }
            // Otherwise, pass the request to the next handler.
            else
            {
                return base.Handle(request);
            }
        }
    }
    
    // Test the results.
    public class Program
    {
        public static void Mein()
        {
            // Create a list of objects.
            var objects = new List<object>() {12.345, 2137, "Hello"};
            
            // Set up the chain.
            var baseHandler = new IntHandler();
            var doubleHandler = new DoubleHandler();
            var stringHandler = new StringHandler();

            baseHandler.SetNext(doubleHandler).SetNext(stringHandler);

            foreach (var elem in objects)
            {
                // Attempt to handle the request.
                Console.WriteLine(baseHandler.Handle(elem));
                
                // If baseHandler cannot handle the request, it will pass it to the next one in chain.
                // The result will be written to console, because each Handle method returns something - even if it's the next one's result.
            }
        }
    }
}