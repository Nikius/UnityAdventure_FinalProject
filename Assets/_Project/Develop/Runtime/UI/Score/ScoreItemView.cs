using _Project.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.Score
{
    public class ScoreItemView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _value;
        
        public void SetName(string text) => _name.text = text;
        public void SetValue(string text) => _value.text = text;
        
    }
}