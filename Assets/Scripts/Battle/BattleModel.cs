using System;

namespace Battle
{
    public class BattleModel : IDisposable
    {
        public readonly Fighter Player;
        public readonly Fighter Opponent;
        private bool _started;

        public BattleModel(Fighter player, Fighter opponent)
        {
            Player = player;
            Opponent = opponent;
            Player.Died += Player_OnDied;
            Opponent.Died += Opponent_OnDied;
        }

        public void Start()
        {
            if (_started) return;
            _started = true;
            Started?.Invoke();
        }

        public event Action Started;

        private void Player_OnDied()
        {
            if (BattleStatus != BattleStatus.InProgress) return;
            BattleStatus = BattleStatus.PlayerLost;
            Opponent.StartCelebrating();
            PlayerLost?.Invoke();
        }

        private void Opponent_OnDied()
        {
            if (BattleStatus != BattleStatus.InProgress) return;
            BattleStatus = BattleStatus.PlayerWon;
            Player.StartCelebrating();
            PlayerWon?.Invoke();
        }

        public BattleStatus BattleStatus { get; private set; } = BattleStatus.InProgress;

        public event Action PlayerWon;
        public event Action PlayerLost;

        public void Dispose()
        {
            Player.Died -= Player_OnDied;
            Opponent.Died -= Opponent_OnDied;
        }
    }
}