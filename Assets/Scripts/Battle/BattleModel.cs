using System;

namespace Battle
{
    public class BattleModel : IDisposable
    {
        public readonly Fighter Player;
        public readonly Fighter Opponent;

        public BattleModel(Fighter player, Fighter opponent)
        {
            Player = player;
            Opponent = opponent;
            Player.Died += Player_OnDied;
            Opponent.Died += Opponent_OnDied;
        }

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