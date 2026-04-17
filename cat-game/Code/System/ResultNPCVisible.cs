using Godot;
using System;

public partial class ResultNPCVisible : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		int score = GameManager.Instance.GetTotalScore();
		int maxScore = GameManager.Instance.GetMaxScore();
		Area2D collision = GetNode<Area2D>("Area2D");
		if (score == maxScore)
		{
			MakeVisible();
			collision.Monitoring = true;
		}
		else
		{
			MakeInvisible();
			collision.Monitoring = false;
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
