using System.Collections.Generic;
using _Project.Develop.Runtime.Gameplay.Services;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenPresenter: IPresenter
    {
        private readonly GameplayScreenView _screen;
        
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly GameTaskService _gameTaskService;
        private readonly UserInputService _userInputService;
        
        private readonly List<IPresenter> _childPresenters = new();
        
        public GameplayScreenPresenter(
            GameplayScreenView screen,
            ProjectPresentersFactory projectPresentersFactory,
            GameTaskService gameTaskService,
            UserInputService userInputService
        ) {
            _screen = screen;
            _projectPresentersFactory = projectPresentersFactory;
            _gameTaskService = gameTaskService;
            _userInputService = userInputService;
        }

        public void Initialize()
        {
            CreateTaskPresenter(_gameTaskService.TaskString);
            CreateUserInputPresenter(_userInputService.InputString);
            
            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();
            
            _childPresenters.Clear();
        }

        private void CreateTaskPresenter(IReadOnlyVariable<string> taskString)
        {
            TextWithLabelPresenter taskPresenter = _projectPresentersFactory.CreateTextWithLabelPresenter(
                _screen.TaskView,
                taskString
            );
            _childPresenters.Add(taskPresenter);
        }
        
        private void CreateUserInputPresenter(IReadOnlyVariable<string> userInputString)
        {
            TextWithLabelPresenter taskPresenter = _projectPresentersFactory.CreateTextWithLabelPresenter(
                _screen.UserInputView,
                userInputString
            );
            _childPresenters.Add(taskPresenter);
        }
    }
}