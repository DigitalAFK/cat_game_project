using Godot;
using System;

public partial class LabelVisible : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		int score = GameManager.Instance.GetTotalScore();
		int maxScore = GameManager.Instance.GetMaxScore();
		if (score == maxScore)
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
