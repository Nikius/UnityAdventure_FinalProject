using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Services
{
    public class UserInputValidationService
    {
        private readonly IReadOnlyVariable<string> _stringForType;

        public UserInputValidationService(IReadOnlyVariable<string> stringForType)
        {
            _stringForType = stringForType;
        }

        public bool IsValid(string userInput) => _stringForType.Value.IndexOf(userInput) == 0;
        
        public bool IsEqual(string userInput) => _stringForType.Value.Equals(userInput);
    }
}