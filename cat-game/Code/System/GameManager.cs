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
	// Static autoproperty.
	// Get on public, so MusicManager can be accessed from anywhere.
	// Set private, so it can't be easily overwritten.
	public static GameManager Instance
	{
		get;
		private set;
	}

	public GameManager()
	{
		//Singleton guarantees only one object of the class can be made at a time
		if (Instance == null)
		{
			//There is no object yet, this will be it
			Instance = this;
		}
		else if (Instance != this)
		{
			//There's already a Singleton object, destroy the one that was just made
			QueueFree();
			return;
		}
	}
	#endregion

	#region Game Data

	private readonly Dictionary<String, bool> _visitedScenes = new();

	private SceneTree _sceneTree = null;

	/// <summary>
	/// Automatically initializing property. Loads the reference to the
	/// scene tree when it is needed for the first time.
	/// </summary>
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

	//Max score is equal to the number of NPCs asking questions
	private int _maxScore = 6;

	/// <summary>
	/// Returns the maximum possible score
	/// </summary>
	/// <returns>max score</returns>
	public int GetMaxScore()
	{
		return _maxScore;
	}

	//TODO: Set scores to zero
	//Etsijä
	private int _finderScore = 0;
	//Etenijä
	private int _advancerScore = 0;
	//Edistäjä
	private int _promoterScore = 0;

	public int GetTotalScore()
	{
		return _finderScore + _advancerScore + _promoterScore;
	}

	/// <summary>
	/// Called when we want to add a point to one of the scores.
	/// Calls CheckScore to make sure the player doesn't already have the maximum amount of points.
	/// </summary>
	/// <param name="type">Type of the desired score</param>
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
			default:
				GD.PrintErr("No score type found for " + type);
				break;
		}
	}

	/// <summary>
	/// Returns the score of the desired type
	/// </summary>
	/// <param name="type">Type of score</param>
	/// <returns>Score of the type</returns>
	/// <exception cref="Exception">If given score type was something not defined</exception>
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

	/// <summary>
	/// Checks how many points the player has in total.
	/// </summary>
	/// <returns>False if too many points, otherwise true</returns>
	private Boolean CheckScore()
	{
		int totalScore = _finderScore + _advancerScore + _promoterScore;
		if (totalScore >= _maxScore)
		{
			return false;
		}
		return true;
	}

	private readonly Dictionary<String, String> names = new();

	public void setName(String id, String name)
	{
		if (names.ContainsKey(id))
		{
			throw new Exception("ID already set for " + id + ", " + name);
		}
		names[id] = name;
	}

	public String getName(String id)
	{
		try
		{
			return names[id];
		}
		catch (KeyNotFoundException)
		{
			GD.PrintErr("The name is not set for id " + id);
			return "[Unknown]";
		}
	}

	private Vector2 _playerVelocity;
	/// <summary>
	/// Set the velocity of the player character.
	/// </summary>
	/// <param name="velocity">Desired velocity</param>
	public void SetPlayerVelocity(Vector2 velocity)
	{
		_playerVelocity = velocity;
	}

	/// <summary>
	/// Returns player character's velocity
	/// </summary>
	/// <returns>Velocity</returns>
	public Vector2 GetPlayerVelocity()
	{
		return _playerVelocity;
	}

	private String _lastExitID;

	/// <summary>
	/// Store the exit the player used
	/// </summary>
	/// <param name="exit"></param>
	public void SetLastExitID(String exit)
	{
		_lastExitID = exit;
	}

	/// <summary>
	/// Get the last exit the player used
	/// </summary>
	/// <returns>Last exit used by the player</returns>
	public String GetLastExitID()
	{
		return _lastExitID;
	}

	private bool _tutorialDone = false;

	public void SetTutorialStatus(bool status)
	{
		_tutorialDone = status;
	}

	public bool GetTutorialStatus()
	{
		return _tutorialDone;
	}

	#endregion
	/// <summary>
	/// Goes to the given scene.
	/// </summary>
	/// <param name="path">Path of the desired scene</param>
	public void GoToScene(string path)
	{
		//Reset the player's velocity
		SetPlayerVelocity(Vector2.Zero);
		//Deferred so that physics processes finish first
		CallDeferred(MethodName.LoadScene, path);
	}

	/// <summary>
	/// Fetches the scene and switches to it if it's loaded successfully.
	/// </summary>
	/// <param name="path">Path of the desired scene</param>
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
