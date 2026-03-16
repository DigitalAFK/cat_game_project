using Godot;
using System;

public partial class AnswerButtonFunction : TextureButton
{
	[Export] private ScoreType type = ScoreType.Finder;
	[Export] private String _targetScenePath = "res://Scenes/Islands/";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	/// <summary>
	/// Detect the button being pressed
	/// </summary>
	public override void _Pressed()
	{
		base._Pressed();
		//TODO: Remove
		GD.Print("Pressed");
		DialogueManagerFunction.Instance.AddScore(type);
		GetTree().ChangeSceneToFile(_targetScenePath);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
