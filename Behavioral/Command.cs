using System;

namespace DesignPatterns.Behavioral.Command
{
    // Converting a request into an object.
    
    // The interface declaring a way to execute a command.
    public interface ICommand
    {
        void Execute();
    }

    // Sample Command classes.
    // These classes represent operations, commands or some logic, in the form of an object.
    public class ConcreteCommand1 : ICommand
    {
        private string _text = String.Empty;

        public ConcreteCommand1(string text)
        {
            _text = text;
        }
        
        public void Execute()
        {
            Console.WriteLine("Executing command1!");
            Console.WriteLine(_text);
        }
    }
    
    public class ConcreteCommand2 : ICommand
    {
        private string _text = String.Empty;

        public ConcreteCommand2(string text)
        {
            _text = text;
        }
        
        public void Execute()
        {
            Console.WriteLine("Executing command2!");
            Console.WriteLine(_text);
        }
    }

    // A class used for invoking commands.
    public class Invoker
    {
        private ICommand _onStart;
        private ICommand _onFinish;
        
        // Initialize commands.
        public void InitializeStart(ICommand onStart)
        {
            _onStart = onStart;
        }
        
        public void InitializeFinish(ICommand onFinish)
        {
            _onFinish = onFinish;
        }

        // Perform and action while executing commands.
        public void DoSomethingImportant()
        {
            if (_onStart is ICommand)
            {
                _onStart.Execute();
            }
            
            Console.WriteLine("Invoker: Doing something right now!");

            if (_onFinish is ICommand)
            {
                _onFinish.Execute();
            }
        }
    }
}