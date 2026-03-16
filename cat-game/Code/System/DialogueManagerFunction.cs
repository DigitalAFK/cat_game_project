using Godot;
using System;

//Different types of score, can be used outside this class:
public enum ScoreType
{
	Finder,
	Advancer,
	Promoter
}
public partial class DialogueManagerFunction : Control
{
	#region Singleton
	public static DialogueManagerFunction Instance
	{
		get;
		private set;
	}

	public DialogueManagerFunction()
	{
		// Singleton takaa, että luokasta voidaan tehdä vain yksi olio kerrallaan.
		if (Instance == null)
		{
			// Ainoata oliota ei ole vielä määritetty. Olkoon tämä olio se.
			Instance = this;
		}
		else if (Instance != this)
		{
			// Singleton-olio on jo olemassa! Tuhotaan juuri luotu olio.
			QueueFree();
			return;
		}
	}

	#endregion

	#region Game Data

	//TODO: Move the points counting to GameManager

	private int _maxScore = 6;
	//Etsijä
	private int _finderScore = 0;
	//Etenijä
	private int _advancerScore = 0;
	//Edistäjä
	private int _promoterScore = 0;

	public void AddScore(ScoreType type)
	{
		switch (type)
		{
			case ScoreType.Finder:
				_finderScore++;
				_finderScore = Mathf.Clamp(_finderScore, 0, _maxScore);
				GD.Print($"Etsijän pisteet nyt: {_finderScore}");
				break;
			case ScoreType.Advancer:
				_advancerScore++;
				_advancerScore = Mathf.Clamp(_advancerScore, 0, _maxScore);
				GD.Print($"Etenijän pisteet nyt: {_advancerScore}");
				break;
			case ScoreType.Promoter:
				_promoterScore++;
				_promoterScore = Mathf.Clamp(_promoterScore, 0, _maxScore);
				GD.Print($"Edistäjän pisteet nyt: {_promoterScore}");
				break;
		}
	}

	public int GetScore(ScoreType type)
	{
		switch (type)
		{
			case ScoreType.Finder:
				return _finderScore;
			case ScoreType.Advancer:
				return _advancerScore;
			case ScoreType.Promoter:
				return _promoterScore;
		}
		throw new Exception("Score type not found");
	}
	#endregion
}
