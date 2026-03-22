using Godot;
using System;
using System.Collections.Generic;

//Different types of score, can be used outside GameManager:
public enum ScoreType
{
	Finder,
	Advancer,
	Promoter
}

public partial class GameManager : Node
{
	#region Singleton
	// Staattinen autoproperty.
	// Get on public, jotta GameManageriin päästään käsiksi mistä vain.
	// Set private, jotta sitä ei voisi helposti ylikirjoittaa.
	public static GameManager Instance
	{
		get;
		private set;
	}

	public GameManager()
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

	private readonly Dictionary<String, bool> _visitedScenes = new();

	private SceneTree _sceneTree = null;

	// Automatically initializing property. Loads the reference to the
	// scene tree when it is needed for the first time.
	public SceneTree SceneTree
	{
		get
		{
			if (_sceneTree == null)
			{
				_sceneTree = GetTree();
			}
			return _sceneTree;
		}
	}

	/// <summary>
	/// Adds the id of the scene to the list of visited scenes
	/// </summary>
	/// <param name="id">ID of the scene</param>
	public void MarkVisitedScene(String id)
	{
		_visitedScenes[id] = true;
	}

	/// <summary>
	/// Checks if the scene id can be found in the collection of visited scenes
	/// </summary>
	/// <param name="id">ID of the scene</param>
	/// <returns>true, if scene was found, false if not</returns>
	public bool HasVisitedScene(String id)
	{
		//Try to find scene id in the collection, if not found, catch the exception it causes
		try
		{
			return _visitedScenes[id];
		}
		catch (KeyNotFoundException)
		{
			return false;
		}
	}

	//Change _maxScore if number of NPCs changes
	private int _maxScore = 6;

	public int GetMaxScore()
	{
		return _maxScore;
	}
	//Etsijä
	private int _finderScore = 3;
	//Etenijä
	private int _advancerScore = 2;
	//Edistäjä
	private int _promoterScore = 1;

	public void AddScore(ScoreType type)
	{
		if (!CheckScore())
		{
			GD.PrintErr("Player has too many points, the maximum is " + _maxScore);
			return;
		}
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

	private Boolean CheckScore()
	{
		int totalScore = _finderScore + _advancerScore + _promoterScore;
		if (totalScore >= _maxScore)
		{
			return false;
		}
		return true;
	}

	#endregion
	public void GoToScene(string path)
	{
		CallDeferred(MethodName.LoadScene, path);
	}

	private void LoadScene(string path)
	{
		// Fetch the scene to be loaded.
		PackedScene nextScene = GD.Load<PackedScene>(path);
		if (nextScene != null)
		{
			// Scene was loaded successfully.
			GetTree().ChangeSceneToFile(path);
		}
		else
		{
			GD.PushError($"Can't load a scene at the path {path}");
		}
	}
}
