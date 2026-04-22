using Godot;
using System;

public partial class TutorialButton : Button
{
	[Export] private TextureRect firstNote;
	[Export] private TextureRect secondNote;

	[Export] private Sprite2D firstArrow;
	[Export] private Sprite2D secondArrow;
	private bool tutorialDone;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		tutorialDone = GameManager.Instance.GetTutorialStatus();
		if (tutorialDone)
		{
			base.Disabled = true;
			base.Visible = false;
			firstNote.Visible = false;
			secondNote.Visible = false;
			firstArrow.Visible = false;
			secondArrow.Visible = false;
		}
	}

	public override void _Pressed()
	{
		base._Pressed();
		if (firstNote.Visible == false)
		{
			secondNote.Visible = false;
			secondArrow.Visible = false;
			base.Disabled = true;
			base.Visible = false;
			GameManager.Instance.SetTutorialStatus(true);   //Tutorial done
			return;
		}
		firstNote.Visible = !firstNote.Visible;
		secondNote.Visible = !secondNote.Visible;
		firstArrow.Visible = !firstArrow.Visible;
		secondArrow.Visible = !secondArrow.Visible;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
