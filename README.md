# ATEA Technical task

This is a .NET Core console application which consists of 3 projects:

 - Console project "ATEATECNICAL.App.csproj"  is responsible for console input/output and communication with user;
 - Utilities project "ATEATECHNICAL.Utils.csproj" contains commonly used utility classes and interfaces and data access classes.
 - Unit tests project "ATEATECHNICAL.Tests.csproj".


## Example of usage
![Alt text](/usageexample.jpg) 

## ATEATECNICAL.App

The program supports two arguments, which can be set via command line arguments at the start of the application, or through the action in app menu.

Menu contains such options: **Set argumets**, **Add arguments to each other**, **Print all arguments stored in the database**, **Quit**.

 - *Set arguments* option is shown when no arguments provided on the start of application, if arguments were set *Set new argumets8 option will appear. Every arguments insert will result into inserting this arguments to database. If awrong amount arguments were provided error will appear. 
 - *Input errors handling* were implemention through try/catch and custom exception class (InvalidInputException).
 - *Add argumnets to each other* is implemented through the extension helper method that tries to parse arguments as int, floats and decimals and if successful then print addition result, if not then concatenate arguments as strings.
 - *Print all arguments stored in the database* is used for selectiong from database and printing all previously used arguments.

Methods in *App.cs* are mostly used for handling user input and help with console printing.

## ATEATECHNICAL.Utils

This project is used as SDK and stores all application tools. It contains *Interfaces*, *Data access*, *Custom exceptions*, *Extensions*, *Models*, *Logger*.

**Data access** was build by implementing the *Repository* pattern, which is reflected in generic IRepository<T> interface and *ArgumentsRepository* class, which is implementing interface for the *ArgumentsModel* class. For the database **LiteDB** implementation was used. Because of it's simplicity and convenience.


## ATEATECHNICAL.Tests
The project contains unit tests for the App class extension method.


-- Add example of usage

