using HealthTech.App.Interfaces;
using HealthTech.App.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace HealthTech.App
{
    class Program
    {
        private static string treeDepth;
        private static string predicatedContainerIndex;
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Balls and Containers Application....");

                ServiceProvider serviceProvider = InitDepencyInjection();

                GetUseInput();

                var validator = serviceProvider.GetService<IValidator>();
                UserInputInfo userInput;
                while ((userInput = validator.IsValid(treeDepth, predicatedContainerIndex)) == null)
                {
                    GetUseInput();
                }

                int _numberOfBalls = ((int)Math.Pow(2, userInput.Depth)) - 1;

                Console.WriteLine("2->Application is creating a binary tree...");

                var processBinaryTree = serviceProvider.GetService<IProcessBinaryTree>();
                var parentNode = processBinaryTree.BuildTree(userInput.Depth);

                Console.WriteLine("3->Application passing balls...");
                var result = processBinaryTree.RunBalls(_numberOfBalls, parentNode);

                Console.WriteLine("4->Searching for empty container...");

                processBinaryTree.FindEmptyContainerId(parentNode, userInput.PredicatedContainerIndex);

                Console.WriteLine($"5->Process is completed.");

                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetUseInput()
        {
            Console.Write("1-> Please enter tree depth(level):");
            treeDepth = Console.ReadLine();

            Console.Write("1-> Please enter Predicated Container Index :");
            predicatedContainerIndex = Console.ReadLine();

        }

        private static ServiceProvider InitDepencyInjection()
        {
            return new ServiceCollection()
                    .AddLogging(cfg => cfg.AddConsole()).Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Debug)
                    .AddSingleton<IProcessBinaryTree, ProcessBinaryTree>()
                    .AddSingleton<IValidator, Validator>()
                    .BuildServiceProvider();
        }
    }

}

