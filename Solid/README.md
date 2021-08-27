[![SOLID banner](https://miro.medium.com/max/2000/1*wrxj0oBKpA_GXb8LPhXOeg.png)](https://medium.com/@ugonnat)

# SOLID Principles

***All illustrations in this reading are
by [Ugonna Thelma](https://medium.com/@ugonnat)**

SOLID is an acronym for the first five object-oriented design (OOD) principles
by Robert C. Martin (also known as Uncle Bob).

> **Note:** While these principles can apply to various programming languages,
> the sample code contained in this reading will use C#.

The SOLID principles were introduced by **Robert C. Martin** in his 2000 paper
[*"Design Principles and Design
Patterns"*](https://fi.ort.edu.uy/innovaportal/file/2032/1/design_principles.pdf)
. These concepts were later built upon by **Michael Feathers**, who introduced
us to the SOLID acronym. And in the last 20 years, these five principles have
revolutionized the world of object-oriented programming, changing the way that
we write software.

SOLID stands for:

- [**S**ingle Responsibility Principle (SRP)](#s---single-responsibility-principle)

- [**O**pen/Closed Principle (OCP)](#o---openclosed-principle)

- [**L**iskov Substitution Principle (LSP)](#l---liskov-substitution-principle)

- [**I**nterface Segregation Principle (ISP)](#i---interface-segregation-principle)

- [**D**ependency Inversion Principle (DIP)](#d---dependency-inversion-principle)

The intention of these principles is to make software designs more
understandable, easier to maintain and easier to extend. As a software engineer,
these 5 principles are essential to know!

## S - Single Responsibility Principle

> *"A class should have one and only one reason to change, meaning that a class
> should have only one job".* Robert C. Martin

In programming, the Single Responsibility Principle states that every module or
class should have responsibility over a single part of the functionality
provided by the software.

[![Single Responsability Principle Image](https://miro.medium.com/max/2000/1*P3oONz9Da3Tc1w97fMV73Q.png)](https://medium.com/@ugonnat)

You may have heard the quote: *"Do one thing and do it well"*. This refers to
the single responsibility principle.

In the article [*"Principles of Object Oriented
Design"*](https://fi.ort.edu.uy/innovaportal/file/2032/1/design_principles.pdf),
Robert C. Martin defines a responsibility as a 'reason to change', and concludes
that a class or module should have one, and only one, reason to be changed.

```c#
class User
{
    private MySQLDatabase _db = new MySQLDatabase();

    public void CreatePost(Post post)
    {
        try
        {
            _db.AddPost(post);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occured: ", ex.ToString());
            File.WriteAllText("\LocalErrors.log", ex.ToString());
        }
    }
}
```

We notice how the `CreatePost()` method has too much responsibility, given that
it can both create a new post, log an error in the database, and log an error in
a local file.

Let’s try to correct it.

```c#
class PostService : IPostService
{
    private ErrorLogger _logger = new ErrorLogger();
    private MySQLDatabase _db = new MySQLDatabase();

    public void CreatePost(User user, Post post)
    {
        try
        {
            _db.AddPost(user, postMessage);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString())
        }
    }
}
```

```c#
class ErrorLogger : ILogger
{
    public void Log(string error)
    {
      Console.WriteLine("An error occured: ", error);
      File.WriteAllText("\LocalErrors.log", error);
    }
}
```

## O - Open/Closed Principle

> *"Objects or entities should be **open** for extension but **closed** for modification".* Bertrand Meyer

In programming, the open/closed principle states that software entities
(classes, modules, functions, etc.) should be open for extensions, but closed
for modification.

[![Open Close Principle Image](https://miro.medium.com/max/2000/1*0MtFBmm6L2WVM04qCJOZPQ.png)](https://medium.com/@ugonnat)

If you have a general understanding of OOP, you probably already know about
polymorphism. We can make sure that our code is compliant with the open/closed
principle by utilizing inheritance and/or implementing interfaces that enable
classes to polymorphically substitute for each other.

The principle does not say "you can't modify the behavior of a component" - it
says, one should **try** to design components in a way they are open for being
reused (or extended) in several ways, **without the need** for modification. This
can be done by providing the right "extension points"

## L - Liskov Substitution Principle

> *"Let q(x) be a property provable about objects of x of type T. Then q(y)
> should be provable for objects y of type S where S is a subtype of T".*
> Barbara Liskov

This one is probably the hardest one to wrap your head around when being
introduced for the first time. But this principle is fairly easy to comprehend.

It states that objects in a program should be replaceable with instances of
their parent types without altering the correctness of that program.

[![Liskov Substitution Principle Image](https://miro.medium.com/max/2000/1*yKk2XKJaCLNlDxQMx1r55Q.png)](https://medium.com/@ugonnat)

The principle defines that objects of a ~~subclass~~ **implementation** shall
be replaceable with objects of its ~~superclass~~ **interface** without breaking the
application. That requires the objects of your implementation behave in the
same way as the as your interface.

It's more convenient to use interfaces instead of classes, because of the
[composite over inheritance](https://en.wikipedia.org/wiki/Composition_over_inheritance).

```c#
class PostService : IPostService
{
    // Use an interface instead of the class
    private ILogger _logger = new ErrorLogger();
    private IDatabase _db = new MySQLDatabase();

    public void CreatePost(User user, Post post)
    {
        try
        {
            _db.AddPost(user, post);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString())
        }
    }
}
```

```c#
class ErrorLogger : ILogger
{
    public void Log(string error)
    {
      Console.WriteLine("An error occured: ", error);
      File.WriteAllText("\LocalErrors.log", error);
    }
}
```

## I - Interface Segregation Principle

> *"A client should never be forced to implement an interface that it doesn't
> use, or clients shouldn't be forced to depend on methods they do not use".*
> Robert C. Martin

[![Interface Segregatio Principle Image](https://miro.medium.com/max/5200/1*2hmyR9L43Vm64MYxj4Y89w.png)](https://medium.com/@ugonnat)

In programming, the interface segregation principle states that no client
should be forced to depend on methods it does not use. Put more simply: Do not
add additional functionality to an existing interface by adding new methods.
Instead, create a new interface and let your class implement multiple
interfaces if needed.

Let’s look at an example of how to violate the ISP.

```c#
// Interface that forces us to implement every method, and make able to the client who uses it to know all its behaviors
interface IPostService
{
    void CreatPost(User user, Post post);
    void DeletePost(PostId id);
    void UpdatePost(PostId id, Post post);
    Post Search(PostId id);
    // ...
}
```

```c#
class PostService : IPostService
{
    private ILogger _logger = new ErrorLogger();
    // Database interface where we have to implement all kind of queries
    private IDatabase _db = new MySQLDatabase();

    public void CreatePost(User user, Post post)
    {
        try
        {
            _db.AddPost(user, post);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString())
        }
    }
    
    // ...
}
```

```c#
class ErrorLogger : ILogger
{
    public void Log(string error)
    {
      Console.WriteLine("An error occured: ", error);
      File.WriteAllText("\LocalErrors.log", error);
    }
}
```

In the above example, We first have a interface with all kind of methods, if we
wanted to extend it we'll also have to break the OCP.

Instead, simply create a new interface.

```c#
// A specific kind of behavior
interface IPostCreator 
{
    void CreatePost(User user, Post post);
}

interface IPostFinder
{
    Post FindPostById(PostId id);
}
```

If any class might need both the `CreatePost` method and the `FindPostById`
method, it will implement both interfaces.

```c#
class PostService : IPostCreator, IPostFinder
{
    private ILogger _logger = new ErrorLogger();
    // Using repository pattern to make specific queries
    private IPostRepository _repository = new MySQLPostRepository();

    public void Create(User user, Post post)
    {
        try
        {
            _repository.AddPost(user, post);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString())
        }
    }
}
```

```c#
class ErrorLogger : ILogger
{
    public void Log(string error)
    {
      Console.WriteLine("An error occured: ", error);
      File.WriteAllText("\LocalErrors.log", error);
    }
}
```

## D - Dependency Inversion Principle

> *"Entities must depend on abstractions, not on concretions. It states that
> the high-level module must not depend on the low-level module, but they
> should depend on abstractions".* Robert C. Martin

In programming, the dependency inversion principle is a way to decouple software modules.
This principle states that

- High-level modules should not depend on low-level modules. Both should depend on abstractions.
- Abstractions should not depend on details. Details should depend on abstractions.

[![Dependency Inversion Principle Image](https://miro.medium.com/max/2000/1*Qk8tDmjQlyvwKxNTfXIo0Q.png)](https://medium.com/@ugonnat)

To comply with this principle, we need to use a design pattern known as a dependency inversion pattern, most often solved by using dependency injection.
Dependency injection is a huge topic and can be as complicated or simple as one might see the need for.

Typically, dependency injection is used simply by ‘injecting’ any dependencies of a class through the class’ constructor as an input parameter.

```c#
interface IPostCreator 
{
    void Create(User user, Post post);
}
```

```c#
class PostService : IPostCreator
{
    private readonly ILogger _logger;
    private readonly IPostRepository _repository;

    // Inject dependencies in constructor to depend on abstraction instead of implementations.
    public PostService(ILogger logger, IPostRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public void Create(User user, Post post)
    {
        try
        {
            _repository.AddPost(user, post);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString())
        }
    }
}
```

```c#
class ErrorLogger : ILogger
{
    public void Log(string error)
    {
      Console.WriteLine("An error occured: ", error);
      File.WriteAllText("\LocalErrors.log", error);
    }
}
```
