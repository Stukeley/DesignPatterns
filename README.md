# DesignPatterns
Several design patters written in C#.
All of them are commented and self-sufficient. Should you need any of them, simply navigate to the right file.

## Currently implemented patterns
### Creational
- **Abstract Factory** - Creates an instance of several families of classes
- **Builder** - Separates object construction from its representation
- **Prototype** - A fully initialized instance to be copied or cloned
- **Singleton** - A class of which only a single instance can exist

### Structural
- **Bridge** - Separates an object’s interface from its implementation
- **Decorator** - Add responsibilities to objects dynamically
- **Facade** - A single class that represents an entire subsystem
- **Proxy** - An object representing another object
- **Composite** - A hierarchy of objects, like a tree or a graph

### Behavioral
- **Iterator** - Sequentially access the elements of a collection
- **Observer** - A way of notifying change to a number of classes
- **Strategy** - A simple way to switch between algorithms and strategies used in a program
- **Chain of Responsibility** - Passing a request along a chain of handlers until one of them takes care of the request
- **Memento** - Making a snapshot of an object that can be restored in the future
- **Command** - Converting a request into an object

### Bonus
- **abstract class** VS **interface**  
More detailed info here: https://stukeleyak.com/2020/09/26/interface-vs-abstract-class/

| Interface | Abstract class |
| --------- | -------------- |
| does not contain a constructor | CAN contain a constructor |
| does not contain static methods | CAN contain static methods |
| can only contain methods and properties | can ALSO contain fields, constants |
| a class can implement many interfaces | a class can only implement ONE other class |
