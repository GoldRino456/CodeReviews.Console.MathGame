using System;

public class GameHistory
{
	private List<GameHistoryEntry> _gameHistory = new List<GameHistoryEntry>();

	public List<GameHistoryEntry>? GetGameHistory()
	{
		if (_gameHistory.Count <= 0)
		{
			return null;
		}
		else
		{
			return _gameHistory.GetRange(0, _gameHistory.Count); //Returns a copy to prevent edits to actual history list
		}
	}

	public void AddEntryToHistory(GameHistoryEntry entry)
	{
		_gameHistory.Add(entry);
	}
}