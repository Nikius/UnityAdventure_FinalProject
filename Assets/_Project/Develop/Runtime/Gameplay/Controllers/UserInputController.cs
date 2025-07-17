using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Controllers
{
    public class UserInputController
    {
        private readonly ReactiveVariable<string> _userInput = new();
        
        public IReadOnlyVariable<string> UserInput => _userInput;
        
        public void Update()
        {
            if (!string.IsNullOrEmpty(Input.inputString))
                _userInput.Value += Input.inputString;
        }
    }
}