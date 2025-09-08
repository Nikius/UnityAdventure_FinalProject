using System.Collections.Generic;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenPresenter: IPresenter
    {
        private readonly GameplayScreenView _screen;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        
        private readonly List<IPresenter> _childPresenters = new();

        public GameplayScreenPresenter(
            GameplayScreenView screen,
            ProjectPresentersFactory projectPresentersFactory
        ) {
            _screen = screen;
            _projectPresentersFactory = projectPresentersFactory;
        }

        public void Initialize()
        {
            _screen.StartWaveButtonClicked += StartWaveButtonClicked;

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            _screen.StartWaveButtonClicked += StartWaveButtonClicked;
            
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();
            
            _childPresenters.Clear();
        }

        private void StartWaveButtonClicked()
        {
            
        }
    }
}