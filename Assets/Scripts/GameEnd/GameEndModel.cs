using System;
using Levels;

namespace GameEnd
{
    public class GameEndModel
    {
        private readonly ILevelManager _levelManager;

        public GameEndModel(ILevelManager levelManager) => _levelManager = levelManager;

        public void OnWon() => Won?.Invoke();

        public event Action Won;

        public void OnLost() => Lost?.Invoke();

        public event Action Lost;

        public void LoadNextLevel() => _levelManager.LoadNext();

        public void ReloadCurrentLevel() => _levelManager.Reload();
    }
}