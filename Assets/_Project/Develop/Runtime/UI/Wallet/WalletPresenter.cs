﻿using System.Collections.Generic;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.Wallet
{
    public class WalletPresenter: IPresenter
    {
        private readonly WalletService _walletService;
        private readonly ProjectPresenterFactory _projectPresenterFactory;
        private readonly ViewsFactory _viewsFactory;

        private readonly IconTextListView _view;
        
        private readonly List<CurrencyPresenter> _currencyPresenters = new();

        public WalletPresenter(
            WalletService walletService,
            ProjectPresenterFactory projectPresenterFactory,
            ViewsFactory viewsFactory,
            IconTextListView view
        ) {
            _walletService = walletService;
            _projectPresenterFactory = projectPresenterFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }
        
        public void Initialize()
        {
            foreach (CurrencyTypes currencyType in _walletService.AvailableCurrencies)
            {
                IconTextView currencyView = _viewsFactory.Create<IconTextView>(ViewIDs.CurrencyView);
                _view.Add(currencyView);
                
                CurrencyPresenter currencyPresenter = _projectPresenterFactory.CreateCurrencyPresenter(
                    currencyView,
                    _walletService.GetCurrency(currencyType),
                    currencyType
                );
                currencyPresenter.Initialize();
                _currencyPresenters.Add(currencyPresenter);
            }
        }

        public void Dispose()
        {
            foreach (CurrencyPresenter currencyPresenter in _currencyPresenters)
            {
                _view.Remove(currencyPresenter.View);
                _viewsFactory.Release(currencyPresenter.View);
                currencyPresenter.Dispose();
            }
            
            _currencyPresenters.Clear();
        }
    }
}