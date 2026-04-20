using Godot;
using System;

public partial class TextureButtonContainerVisibility : TextureButton
{
	private VBoxContainer _targetContainer;
	[Export] private String _targetContainerPath = "";
	[Export] private AudioStream stream = GD.Load<AudioStream>("res://Audio/SFX/Button_Press.wav");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_targetContainer = GetNode<VBoxContainer>(_targetContainerPath);
	}

	//Called when the TextureButton is pressed
	public override void _Pressed()
	{
		base._Pressed();
		MusicManager.Instance.PlaySound(stream);
		_targetContainer.Visible = !_targetContainer.Visible;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
