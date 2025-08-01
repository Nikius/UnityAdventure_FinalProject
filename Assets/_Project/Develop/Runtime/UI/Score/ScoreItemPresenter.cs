using System;
using _Project.Develop.Runtime.Meta.Features.Score;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.UI.Score
{
    public class ScoreItemPresenter: IPresenter
    {
        private readonly IReadOnlyVariable<int> _value;
        private readonly ScoreTypes _scoreType;
        
        private readonly ScoreItemView _view;

        private IDisposable _disposable;

        public ScoreItemPresenter(
            IReadOnlyVariable<int> value,
            ScoreTypes scoreType,
            ScoreItemView view
        ) {
            _value = value;
            _scoreType = scoreType;
            _view = view;
        }
        
        public ScoreItemView View => _view;

        public void Initialize()
        {
            UpdateValue(_value.Value);
            _view.SetName(_scoreType.ToString());
            _disposable = _value.Subscribe(OnValueChanged);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        private void OnValueChanged(int olValue, int newValue) => UpdateValue(newValue);

        private void UpdateValue(int value) => _view.SetValue(value.ToString());
    }
}