using Godot;
using System;

public partial class PlayButtonFunction : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	//Called when the TextureButton is pressed
	public override void _Pressed()
	{
		base._Pressed();
		//TODO: Remove
		GD.Print("Pressed");
		GameManager.Instance.GoToScene("res://Scenes/Characters/Sea.tscn");
		//GetTree().ChangeSceneToFile("res://Scenes/Characters/Sea.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
