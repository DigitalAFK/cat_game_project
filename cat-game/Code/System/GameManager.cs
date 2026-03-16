using Godot;
using System;
using System.Collections.Generic;

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

	#endregion
}
