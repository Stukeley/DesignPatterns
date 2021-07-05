using System;

namespace DesignPatterns.Behavioral.Strategy
{
    // A simple way to switch between algorithms and strategies used in a program.
    
    // This abstract class' object will live in the Target class.
    public abstract class Strategy
    {
        public abstract double Calculate(double input);
    }

    // Different implementations of the "Strategy" - such as different functions, algorithms, etc.
    // Aka. "Concrete strategies".
    public class Linear : Strategy
    {
        public override double Calculate(double input)
        {
            return input;
        }
    }

    public class Quadratic : Strategy
    {
        public override double Calculate(double input)
        {
            return input * input;
        }
    }

    public class Trigonometric : Strategy
    {
        public override double Calculate(double input)
        {
            return Math.Sin(input);
        }
    }
    
    // Target class.
    public class Target
    {
        // Strategy object - can be any concrete strategy (Linear, Quadratic, Trigonometric).
        // This object could also be static in case we want the same strategy to be used in all instances of the class.
        private Strategy Strategy { get; set; }

        // The given strategy is passed in the constructor.
        public Target(Strategy strategy)
        {
            Strategy = strategy;
        }

        public double DoAlgorithm(double input)
        {
            var output = Strategy.Calculate(input);
            return output;
        }
    }
    
    // Static Strategy example.
    public class StaticTarget
    {
        private static Strategy Strategy { get; set; }

        // This function should be invoked at the start of the program, if using the static variant.
        public void SetStrategy(Strategy strategy)
        {
            Strategy = strategy;
        }

        public double DoAlgorithm(double input)
        {
            var output = Strategy.Calculate(input);
            return output;
        }
    }
}