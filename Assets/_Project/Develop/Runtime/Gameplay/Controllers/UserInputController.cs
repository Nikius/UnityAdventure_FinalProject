using _Project.Develop.Runtime.Gameplay.Services;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Controllers
{
    public class UserInputController
    {
        private readonly UserInputService _userInputService;

        public UserInputController(UserInputService userInputService)
        {
            _userInputService = userInputService;
        }

        public void Update()
        {
            if (!string.IsNullOrEmpty(Input.inputString))
                _userInputService.AddToInputString(Input.inputString);
        }
    }
}