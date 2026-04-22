using Godot;
using System;

public partial class LanguageButton : TextureButton
{
	[Export] AudioStream stream;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (GameManager.Instance.GetLanguage() == "en")
		{
			GameManager.Instance.SetLanguage("fi");
		}
	}

	public override void _Pressed()
	{
		MusicManager.Instance.PlaySound(stream);
		bool toggled = base.ButtonPressed;
		OnTextureButtonToggled(toggled);
	}

	public void OnTextureButtonToggled(bool english)
	{
		if (english)
		{
			GameManager.Instance.SetLanguage("en");
			return;
		}
		GameManager.Instance.SetLanguage("fi");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
