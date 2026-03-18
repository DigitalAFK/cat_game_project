using Godot;
using System;

public partial class VolumeSlider : HSlider
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	//TODO: Figure out how to get the drag data and use that to change volume once we have audio
	public override Variant _GetDragData(Vector2 atPosition)
	{
		return base._GetDragData(atPosition);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
