using HealthTech.App.Interfaces;
using System;

namespace HealthTech.App
{
    public class Validator : IValidator
    {       
        public bool IsValid(string treeDepth)
        {
            if (string.IsNullOrEmpty(treeDepth))
            {
               Console.WriteLine ($"Please enter a valid number {nameof(treeDepth)}.");
                return false;
            }
            if (!int.TryParse(treeDepth, out int _treeDepth) || _treeDepth <= 0)
            {
                Console.WriteLine("Tree depth must be a positive number.");
                return false;
            }          
            return true;
        }
    }
}
