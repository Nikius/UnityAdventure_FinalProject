using System;
using System.Collections.Generic;
using _Project.Develop.Runtime.UI.Core.TestPopup;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.Core
{
    public abstract class PopupService: IDisposable
    {
        protected readonly ViewsFactory ViewsFactory;

        private readonly ProjectPresenterFactory _presenterFactory;
        private readonly Dictionary<PopupPresenterBase, PopupInfo> _presenterToInfo = new();

    protected PopupService(
            ViewsFactory viewsFactory,
            ProjectPresenterFactory presenterFactory
        ) {
            ViewsFactory = viewsFactory;
            _presenterFactory = presenterFactory;
        }

        protected abstract Transform PopupLayer { get; }

        public TestPopupPresenter OpenTestPopup(Action closedCallback = null)
        {
            TestPopupView view = ViewsFactory.Create<TestPopupView>(ViewIDs.TestPopup, PopupLayer);
            
            TestPopupPresenter popup = _presenterFactory.CreateTestPopupPresenter(view);
            
            OnPopupCreated(popup, view, closedCallback);

            return popup;
        }

        public void ClosePopup(PopupPresenterBase popup)
        {
            popup.CloseRequest -= ClosePopup;

            popup.Hide(() =>
            {
                _presenterToInfo[popup].ClosedCallback?.Invoke();
                
                DisposeFor(popup);
                _presenterToInfo.Remove(popup);
            });
        }

        public void Dispose()
        {
            foreach (PopupPresenterBase popup in _presenterToInfo.Keys)
            {
                popup.CloseRequest -= ClosePopup;
                DisposeFor(popup);
            }
            
            _presenterToInfo.Clear();
        }

        protected void OnPopupCreated(
            PopupPresenterBase popup,
            PopupViewBase view,
            Action closedCallback = null
        ) {
            PopupInfo popupInfo = new(view, closedCallback);
            
            _presenterToInfo.Add(popup, popupInfo);
            popup.Initialize();
            popup.Show();

            popup.CloseRequest += ClosePopup;
        }

        private void DisposeFor(PopupPresenterBase popup)
        {
            popup.Dispose();
            ViewsFactory.Release(_presenterToInfo[popup].View);
        }
    }
}