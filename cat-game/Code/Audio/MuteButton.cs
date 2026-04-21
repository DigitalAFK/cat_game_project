using Godot;
using System;

public partial class MuteButton : TextureButton
{
	[Export] private AudioStream stream = GD.Load<AudioStream>("res://Audio/SFX/Button_Press.wav");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (MusicManager.Instance.GetMuteStatus())
		{
			base.ButtonPressed = true;
			return;
		}
		base.ButtonPressed = false;
	}

	public override void _Pressed()
	{
		base._Pressed();
		MusicManager.Instance.PlaySound(stream);
		bool toggled = base.ButtonPressed;
		OnTextureButtonToggled(toggled);
	}

	public void OnTextureButtonToggled(bool off)
	{
		if (off)
		{
			MusicManager.Instance.MuteAllSounds();
			return;
		}
		MusicManager.Instance.UnmuteAllSounds();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
