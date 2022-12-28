# ATEA Technical task

This is a .NET Core console application which consists of 3 projects:

 - Console project "ATEATECNICAL.App.csproj"  is responsible for console input/output and communication with user;
 - Utilities project "ATEATECHNICAL.Utils.csproj" contains commonly used utility classes and interfaces and data access classes.
 - Unit tests project "ATEATECHNICAL.Tests.csproj".


## Example of usage
![Alt text](/usageexample.jpg) 

On the start of application if no agruments were provided user can have two options: Enter new arguments(*1.Set arguments*) or Show previously entered(3.*Print all arguments from database*).
If user select *Set arguments option* application will providehim example of argumets and ask to writee arguments separated by whitespace. After arguments are entered user can add arguments to each other (*2. Add arguments to each other*). If arguments were numbers (int, float, decimal) user will get sum of them as result. If one of arguments was string then application will concatenate them.

## ATEATECNICAL.App

The program supports two arguments, which can be set via command line arguments at the start of the application, or through the action in app menu.

Menu contains such options: **Set argumets**, **Add arguments to each other**, **Print all arguments stored in the database**, **Quit**.

 - *Set arguments* option is shown when no arguments provided on the start of application, if arguments were set *Set new argumets* option will appear. Every arguments insert will result into inserting this arguments to database. If awrong amount arguments were provided error will appear. 
 - *Input errors handling* were implemented through try/catch and custom exception class (InvalidInputException).
 - *Add argumnets to each other* is implemented through the extension helper method that tries to parse arguments as int, floats and decimals and if successful then print addition result, if not then concatenate arguments as strings.
 - *Print all arguments stored in the database* is used for selectiong from database and printing all previously used arguments.

Methods in *App.cs* are mostly used for handling user input and help with console printing.

## ATEATECHNICAL.Utils

This project is used as SDK and stores all application tools. It contains *Interfaces*, *Data access*, *Custom exceptions*, *Extensions*, *Models*, *Logger*.

**Data access** was build by implementing the *Repository* pattern, which is reflected in generic IRepository<T> interface and *ArgumentsRepository* class, which is implementing interface for the *ArgumentsModel* class. For the database **LiteDB** implementation was used. Because of it's simplicity and convenience.


## ATEATECHNICAL.Tests
The project contains unit tests for the App class extension method.

