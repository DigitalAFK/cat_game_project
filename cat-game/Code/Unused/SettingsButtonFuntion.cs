using Godot;
using System;

public partial class SettingsButtonFuntion : TextureButton
{
	private VBoxContainer _settingsContainer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_settingsContainer = GetNode<VBoxContainer>("../../../SettingsContainer");
	}

	//Called when the TextureButton is pressed
	public override void _Pressed()
	{
		base._Pressed();
		//TODO: Remove
		GD.Print("Pressed");
		_settingsContainer.Visible = true;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
