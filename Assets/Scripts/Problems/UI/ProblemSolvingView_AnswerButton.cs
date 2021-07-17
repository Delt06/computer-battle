using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Problems.UI
{
    public class ProblemSolvingView_AnswerButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;

        public Button Button => _button;

        public TMP_Text Text => _text;
    }
}