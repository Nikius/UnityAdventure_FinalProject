using System;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class TextWithLabelPresenter: IPresenter
    {
        private readonly IReadOnlyVariable<string> _value;
        
        private readonly TextWithLabelView _view;

        private IDisposable _disposable;

        public TextWithLabelPresenter(
            IReadOnlyVariable<string> value,
            TextWithLabelView view
        ) {
            _value = value;
            _view = view;
        }
        
        public TextWithLabelView View => _view;

        public void Initialize()
        {
            UpdateValue(_value.Value);
            _disposable = _value.Subscribe(OnValueChanged);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        private void OnValueChanged(string olValue, string newValue) => UpdateValue(newValue);

        private void UpdateValue(string value) => _view.SetText(value);
    }
}