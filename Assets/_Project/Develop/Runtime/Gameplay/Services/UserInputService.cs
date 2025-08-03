using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Services
{
    public class UserInputService
    {
        private readonly ReactiveVariable<string> _inputString;
        
        public UserInputService(ReactiveVariable<string> inputString)
        {
            _inputString = inputString;
        }

        public IReadOnlyVariable<string> InputString => _inputString;
        
        public void SetInputString(string value) => _inputString.Value = value;
        
        public void AddToInputString(string value) => _inputString.Value += value;
    }
}