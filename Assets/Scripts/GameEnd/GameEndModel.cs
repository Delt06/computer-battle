using System;

namespace GameEnd
{
    public class GameEndModel
    {
        public void OnWon() => Won?.Invoke();

        public event Action Won;

        public void OnLost() => Lost?.Invoke();

        public event Action Lost;
    }
}