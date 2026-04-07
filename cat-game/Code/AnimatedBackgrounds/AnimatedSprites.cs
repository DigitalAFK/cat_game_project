using Godot;
using System;

public partial class AnimatedSprites : Sprite2D
{
	[Export] int _frameAmount = 2;
	[Export] int _animationSpeed = 8;
	int frame = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (frame % _animationSpeed == 0)
		{
			if (Frame < _frameAmount - 1)
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
