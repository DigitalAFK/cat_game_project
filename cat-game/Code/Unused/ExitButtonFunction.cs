using Godot;
using System;

public partial class ExitButtonFunction : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _Pressed()
	{
		base._Pressed();
		//TODO: Remove
		GD.Print("Pressed");
		GetTree().ChangeSceneToFile("res://Scenes/StillScreens/MainMenu.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
