using _Project.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class TextWithLabelView: MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _text;
        
        public void SetText(string text) => _text.text = text;
        
    }
}