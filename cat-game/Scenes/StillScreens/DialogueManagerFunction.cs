using Godot;
using System;

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

	private int _maxScore = 6;
	//Etsijä
	private int _finderScore = 0;
	//Etenijä
	private int _advancerScore = 0;
	//Edistäjä
	private int _promoterScore = 0;
	public int FinderScore
	{
		get { return _finderScore; }
		set
		{
			_finderScore = Mathf.Clamp(value, 0, _maxScore);
			GD.Print($"Pisteet nyt: {FinderScore}");
		}
	}

	public int AdvancerScore
	{
		get { return _advancerScore; }
		set
		{
			_advancerScore = Mathf.Clamp(value, 0, _maxScore);
			GD.Print($"Pisteet nyt: {AdvancerScore}");
		}
	}

	public int PromoterScore
	{
		get { return _promoterScore; }
		set
		{
			_promoterScore = Mathf.Clamp(value, 0, _maxScore);
			GD.Print($"Pisteet nyt: {PromoterScore}");
		}
	}
	#endregion

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
