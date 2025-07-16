namespace _Project.Develop.Runtime.Gameplay.Services
{
    public class UserInputValidationService
    {
        private readonly string _stringForType;

        public UserInputValidationService(string stringForType)
        {
            _stringForType = stringForType;
        }

        public bool IsValid(string userInput) => _stringForType.IndexOf(userInput) == 0;
        
        public bool IsEqual(string userInput) => _stringForType.Equals(userInput);
    }
}