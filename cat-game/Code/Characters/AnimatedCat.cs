using Godot;
using System;

public partial class AnimatedCat : Sprite2D
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
		//Flip the ship horizontally depending on which way it's going
		Vector2 direction = GameManager.Instance.GetPlayerVelocity();

		float directionX = direction.X;
		float directionY = direction.Y;

		if (directionX > 0 && directionX >= 0.45)
		{
			Texture = GD.Load<Texture2D>("res://Art/Sprites/catspriteright.png");
		}
		else if (directionX < 0 && directionX <= -0.45)
		{
			Texture = GD.Load<Texture2D>("res://Art/Sprites/catspriteleft.png");
		}
		else if (directionY < 0 && directionY < 0.45)
		{
			Texture = GD.Load<Texture2D>("res://Art/Sprites/catspriteback.png");
		}
		else if (directionY > 0 && directionY > -0.45)
		{
			Texture = GD.Load<Texture2D>("res://Art/Sprites/catsprite.png");
		}

		//Handle the switching of the animation's frames in accordance to set speed
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
