namespace Battle
{
	public class BattleModel
	{
		public readonly Fighter Opponent;
		public readonly Fighter Player;

		public BattleModel(Fighter player, Fighter opponent)
		{
			Player = player;
			Opponent = opponent;
		}
	}
}