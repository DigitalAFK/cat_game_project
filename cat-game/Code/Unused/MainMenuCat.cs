using Godot;
using System;

public partial class MainMenuCat : Sprite2D
{
	int frame = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (frame % 8 == 0)
		{
			if (Frame < 11)
			{
				Frame += 1;
			}
			else
			{
				Frame = 0;
			}
		}
		frame++;
	}
}
