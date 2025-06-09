using System;

public class GameHistoryEntry
{
	private int _gameType;
	private int _score;

	public int GameType { get { return _gameType; } }
	public int Score { get { return _score; } }

	public GameHistoryEntry(int gameType, int score)
	{
		_gameType = gameType;
		_score = score;
	}
}
