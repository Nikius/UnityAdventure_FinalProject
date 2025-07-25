using System;

namespace _Project.Develop.Runtime.UI.Core
{
    public class PopupInfo
    {
        public PopupInfo(PopupViewBase view, Action closedCallback)
        {
            View = view;
            ClosedCallback = closedCallback;
        }

        public PopupViewBase View { get; }
        public Action ClosedCallback { get; }
    }
}