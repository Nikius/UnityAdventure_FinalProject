using _Project.Develop.Runtime.UI.Core;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenView: MonoBehaviour, IView
    {
        [field: SerializeField] public TextWithLabelView TaskView { get; private set; }
        [field: SerializeField] public TextWithLabelView UserInputView { get; private set; }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }
    }
}