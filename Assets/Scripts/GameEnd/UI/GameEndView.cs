using Shared.UI;
using UnityEngine;

namespace GameEnd.UI
{
    public class GameEndView : View<GameEndPresenter>
    {
        [SerializeField] private GameObject _winScreen;
        [SerializeField] private GameObject _loseScreen;

        public void ShowWinScreen()
        {
            _winScreen.SetActive(true);
        }

        public void ShowLoseScreen()
        {
            _loseScreen.SetActive(true);
        }
    }
}