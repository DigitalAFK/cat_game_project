using Godot;
using System;

public partial class ButtonFunction : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	//Called when the TextureButton is pressed
	public override void _Pressed()
	{
		base._Pressed();
		GD.Print("Pressed");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
