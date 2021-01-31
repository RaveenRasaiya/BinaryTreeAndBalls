using HealthTech.App.Interfaces;
using HealthTech.App.Models;
using System;

namespace HealthTech.App
{
    public class Validator : IValidator
    {
        public UserInputInfo IsValid(string treeDepth, string predicatedContainerIndex)
        {
            UserInputInfo userInputInfo = null;
            if (string.IsNullOrEmpty(treeDepth))
            {
                Console.WriteLine($"Please enter a valid number {nameof(treeDepth)}.");
                return userInputInfo;
            }
            if (!int.TryParse(treeDepth, out int _treeDepth) || _treeDepth <= 0)
            {
                Console.WriteLine("Tree depth must be a positive number.");
                return userInputInfo;
            }
            if (string.IsNullOrEmpty(predicatedContainerIndex))
            {
                Console.WriteLine($"Please enter a valid number {nameof(predicatedContainerIndex)}.");
                return userInputInfo;
            }
            if (!int.TryParse(predicatedContainerIndex, out int _predicatedContainerIndex) || _predicatedContainerIndex <= 0)
            {
                Console.WriteLine("Predicated Container Index must be a positive number.");
                return userInputInfo;
            }
            if (_predicatedContainerIndex > Math.Pow(2, _treeDepth))
            {
                Console.WriteLine("The predicated container index should be less tha power of tree depth");
                return userInputInfo;
            }
            userInputInfo = new UserInputInfo
            {
                IsSuccess = true,
                Depth = _treeDepth,
                PredicatedContainerIndex = _predicatedContainerIndex
            };
            return userInputInfo;
        }
    }
}
