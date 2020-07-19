# DesignPatterns
Several design patters written in C#.

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

### Behavioral
- **Iterator** - Sequentially access the elements of a collection
- **Observer** - A way of notifying change to a number of classes

### Bonus
- **abstract class** VS **interface**  

| Interface | Abstract class |
| --------- | -------------- |
| does not contain a constructor | CAN contain a constructor |
| does not contain static methods | CAN contain static methods |
| can only contain methods and properties | can ALSO contain fields, constants |
| a class can implement many interfaces | a class can only implement ONE other class |
