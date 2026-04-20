using Godot;
using System;

public partial class Audio : Node
{
	[Export] private AudioStream stream;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MusicManager.Instance.PlayMusic(stream);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
