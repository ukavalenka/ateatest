using ATEATECHNICAL.Utils;
using ATEATECHNICAL.Utils.DataAccess;
using ATEATECHNICAL.Utils.Exceptions;
using ATEATECHNICAL.Utils.Extensions;
using ATEATECHNICAL.Utils.Interfaces;
using ATEATECHNICAL.Utils.Models;
using System;
using System.Linq;

namespace ATEATECHNICAL.App
{
    public class App : IDisposable
    {
        private string _arg1;
        private string _arg2;
        private bool _isStopRequested;
        private IRepository<ArgumentsModel> _repository;
        private ILogger _logger;

        public App()
        {
            _isStopRequested = false;
            _logger = new ConsoleLogger();
            
            _repository = new ArgumentsRepository(_logger);
        }

        ~App()
        {
            Dispose();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public void Run(string[] arguments = null)
        {
            if (arguments != null && arguments.Length > 0)
            {
                if (arguments.Length != 2)
                {
                    _logger.Log("Invalid amount of arguments.");
                }
                else
                {
                    _arg1 = arguments[0];
                    _arg2 = arguments[1];
                    _repository.Insert(new ArgumentsModel(_arg1, _arg2));
                }
            }

            Console.WriteLine("Welcome!");

            while(!_isStopRequested)
            {
                try
                {
                    PrintCurrentArguments();
                    PrintMenu();
                    ExecuteUserAction();
                    Console.WriteLine("------------------");
                } 
                catch(Exception ex)
                {
                    _logger.Log(ex.Message);
                }
            }
            
        }

        private void PrintCurrentArguments()
        {
            if (!AreArgumentsFilled())
            {
                Console.WriteLine("Arguments not set");
                return;
            }

            Console.WriteLine($"Current args: arg1 = {_arg1}; arg2 = {_arg2}");
        }

        private void PrintMenu()
        {
            Console.WriteLine($"\n1. Set{(AreArgumentsFilled() ? " new" : string.Empty)} arguments");

            if (AreArgumentsFilled())
            {
                Console.WriteLine($"2. Add arguments to each other");
            }
            Console.WriteLine($"3. Print all arguments from database");
            Console.WriteLine($"ESC. Quit"); 
        }

        private void ExecuteUserAction()
        {
            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    {
                        SetArguments();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        PrintAdditionResult();
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        var records = _repository.GetAll();
                        if (!records.Any())
                            Console.WriteLine("\nDatabase didn't return any records!");
                        else
                            PrintDatabaseRecords(records.ToArray());
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        _isStopRequested = true;
                        Console.WriteLine("Application stopped");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nWrong input. Try again");
                        break;
                    }
            }
        }

        private void SetArguments()
        {
            Console.WriteLine("\nEnter two arguments separated by a whitespace.\nExample [firstargument secondargument]");

            string input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
                throw new InvalidInputException("Input is empty");

            string[] agrs = input.Split(' ').Select(e => e.Trim()).Where(e => !string.IsNullOrWhiteSpace(e)).ToArray();

            if (agrs.Length != 2)
                throw new InvalidInputException("Please enter 2 aruments separated by whitespace");


            _arg1 = agrs[0];
            _arg2 = agrs[1];

            _repository.Insert(new ArgumentsModel(_arg1, _arg2));
        }

        private bool AreArgumentsFilled()
        {
            return _arg1 != null && _arg2 != null;
        }

        private void PrintAdditionResult()
        {
            Console.WriteLine($"\nResult: {_arg1.AddArgument(_arg2)}");
        }


        private void PrintDatabaseRecords(params ArgumentsModel[] arguments)
        {
            Console.WriteLine("\n Arguments:");
            foreach (ArgumentsModel argument in arguments)
            {
                Console.WriteLine($"{argument.Id}. Arg1 = {argument.Arg1}; Arg2 = {argument.Arg2};");
            }
        }
    }
}

