using DELTation.UI.Screens;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Plugins.DELTation.UI.Utils
{
    [RequireComponent(typeof(Button))]
    public sealed class CloseScreenButton : MonoBehaviour
    {
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
            _gameScreen = GetComponentInParent<GameScreen>();
            _onClick = () => _gameScreen.Close();
        }

        private Button _button;
        private GameScreen _gameScreen;
        private UnityAction _onClick;
    }
}