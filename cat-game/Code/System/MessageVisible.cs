using Godot;
using System;

public partial class MessageVisible : TextureRect
{
	[Export] private string _shintaroID = "NPC007";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		int score = GameManager.Instance.GetTotalScore();
		int maxScore = GameManager.Instance.GetMaxScore();
		bool hasSeenShintaro = GameManager.Instance.HasVisitedScene(_shintaroID);
		if (score == maxScore && !hasSeenShintaro)
		{
			MakeVisible();
		}
		else
		{
			MakeInvisible();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void MakeVisible()
	{
		Visible = true;
	}
	public void MakeInvisible()
	{
		Visible = false;
	}
}
