﻿using System;
using _Project.Develop.Runtime.Configs.Meta.Wallet;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.UI.Wallet
{
    public class CurrencyPresenter: IPresenter
    {
        // business logic
        private readonly IReadOnlyVariable<int> _currency;
        private readonly CurrencyTypes _currencyType;
        private readonly CurrencyIconsConfig _currencyIconsConfig;
        
        // view
        private readonly IconTextView _view;

        private IDisposable _disposable;

        public CurrencyPresenter(
            IReadOnlyVariable<int> currency,
            CurrencyTypes currencyType,
            CurrencyIconsConfig currencyIconsConfig,
            IconTextView view
        ) {
            _currency = currency;
            _currencyType = currencyType;
            _currencyIconsConfig = currencyIconsConfig;
            _view = view;
        }
        
        public IconTextView View => _view;
        
        public void Initialize()
        {
            UpdateValue(_currency.Value);
            _view.SetIcon(_currencyIconsConfig.GetSpriteFor(_currencyType));

            _disposable = _currency.Subscribe(OnCurrencyChanged);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        private void OnCurrencyChanged(int olValue, int newValue) => UpdateValue(newValue);
        
        private void UpdateValue(int value) => _view.SetText(value.ToString());
    }
}