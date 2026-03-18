using Godot;
using System;

public partial class TextureButtonFunction : TextureButton
{
	[Export] private string _targetScenePath = "res://Scenes/";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _Pressed()
	{
		base._Pressed();
		//TODO: Remove print
		GD.Print("Pressed");
		GameManager.Instance.GoToScene(_targetScenePath);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
