The .NET Core ORM Cookbook
==============

In October of 2016, InfoQ published a series of articles on the repository pattern in .NET. To illustrate the concepts three ORMs were demonstrated:  Entity Framework, Dapper, and Chain. 

A criticism of the articles was that it didn’t include many people’s favorite ORM. So as a follow up, this GitHub repository was created to expand on that idea and create a shared “cookbook” of design patterns for any or all of the .NET ORMs. Contributions are welcome.

In December of 2019, the ORM Cookbook project was revived with an emphasis on modern, production grade programming. This means that each example must take into consideration these factors:

* Exception handling
* .NET Core Support
* C# 8 Nullable Reference Types
* Static Code Analysis (e.g. FxCopAnalyzers)

When contributing recipes, please keep in mind the best practices for the ORM you are working with as novices may be using the code without fully understanding it. 

### Original InfoQ Articles

* [Implementation Strategies for the Repository Pattern with Entity Framework, Dapper, and Chain](https://www.infoq.com/articles/repository-implementation-strategies)
* [Advanced Use Cases for the Repository Pattern in .NET]( https://www.infoq.com/articles/repository-advanced)

## Presentation

[The ORM Cookbook Repository](https://github.com/Grauenwolf/DotNet-ORM-Cookbook)

Each ORM is presented as its own xUnit test project. The actual recipes are in the Models and Repositories folder. 

To ensure each ORM is "playing by the rules", a shared set of tests will be used. The tests are arranged into "use cases" classes. Each ORM can opt in for a given use case by inheriting from the appropriate use case class. This can be done multiple times if the ORM wishes to demonstrate alternate patterns.

Each use case has a matching markdown file in which the code samples can be added along with any relevant explanations. When possible, use [Projbook]( http://defrancea.github.io/Projbook/) notation to inline code samples. This will prevent the code samples from getting out of sync with the documentation.

If you build the “Documentation” project, the cookbook will be compiled as a website. 


