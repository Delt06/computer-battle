using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Problems.UI
{
    public class ProblemSolvingView_AnswerButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Color _finalTextColor = Color.white;
        [SerializeField] private GameObject _normal = default;
        [SerializeField] private GameObject _selected = default;
        [SerializeField] private GameObject _correct = default;
        [SerializeField] private GameObject _incorrect = default;
        [SerializeField] private GameObject _selectionFrame = default;

        private Color _normalTextColor;
        private GameObject[] _allStates;

        public Button Button => _button;

        public TMP_Text Text => _text;

        public void MakeNormal()
        {
            ActivateOnly(_normal);
            _selectionFrame.SetActive(false);
            _text.color = _normalTextColor;
        }

        public void MakeSelected()
        {
            ActivateOnly(_selected);
            _text.color = _finalTextColor;
            _selectionFrame.SetActive(true);
        }

        public void MakeCorrect()
        {
            ActivateOnly(_correct);
            _text.color = _finalTextColor;
        }

        public void MakeIncorrect()
        {
            ActivateOnly(_incorrect);
            _text.color = _finalTextColor;
        }

        private void ActivateOnly(GameObject activeState)
        {
            foreach (var state in _allStates)
            {
                state.SetActive(state == activeState);
            }
        }

        private void Awake()
        {
            _normalTextColor = _text.color;
            _allStates = new[] { _normal, _selected, _correct, _incorrect };
        }
    }
}