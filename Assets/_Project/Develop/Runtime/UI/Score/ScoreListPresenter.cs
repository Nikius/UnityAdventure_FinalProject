using System.Collections.Generic;
using _Project.Develop.Runtime.Meta.Features.Score;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.Score
{
    public class ScoreListPresenter: IPresenter
    {
        private readonly ScoreService _scoreService;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private readonly ScoreListView _view;
        
        private readonly List<ScoreItemPresenter> _scoreItemPresenters = new();

        public ScoreListPresenter(
            ScoreService scoreService,
            ProjectPresentersFactory projectPresentersFactory,
            ViewsFactory viewsFactory,
            ScoreListView view
        ) {
            _scoreService = scoreService;
            _projectPresentersFactory = projectPresentersFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        public void Initialize()
        {
            foreach (ScoreTypes scoreType in _scoreService.AvailableScores)
            {
                ScoreItemView scoreView = _viewsFactory.Create<ScoreItemView>(ViewIDs.ScoreItemView);
                _view.Add(scoreView);
                
                ScoreItemPresenter scoreItemPresenter = _projectPresentersFactory.CreateScoreItemPresenter(
                    scoreView,
                    _scoreService.GetScore(scoreType),
                    scoreType
                );
                scoreItemPresenter.Initialize();
                _scoreItemPresenters.Add(scoreItemPresenter);
            }
        }

        public void Dispose()
        {
            foreach (ScoreItemPresenter scoreItemPresenter in _scoreItemPresenters)
            {
                _view.Remove(scoreItemPresenter.View);
                _viewsFactory.Release(scoreItemPresenter.View);
                scoreItemPresenter.Dispose();
            }
            
            _scoreItemPresenters.Clear();
        }
    }
}