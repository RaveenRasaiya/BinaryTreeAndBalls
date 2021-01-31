using HealthTech.App.Models;

namespace HealthTech.App.Interfaces
{
    public interface IValidator
    {
        UserInputInfo IsValid(string treeDepth,string predicatedContainerIndex);
    }
}
