using DELTation.UI.Screens;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Plugins.DELTation.UI.Utils
{
    [RequireComponent(typeof(Button))]
    public sealed class OpenScreenButton : MonoBehaviour
    {
        [SerializeField] private GameScreen _gameScreen = default;

        private void OnEnable()
        {
            _button.onClick.AddListener(_onClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(_onClick);
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _onClick = () => _gameScreen.Open();
        }

        private Button _button;
        private UnityAction _onClick;
    }
}