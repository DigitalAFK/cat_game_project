using Godot;
using System;

public partial class NewPlayerCharacter : CharacterBody2D
{
	[Export] public float Speed = 550.0f;
	[Export] public float Friction = 350.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 targetVelocity = GameManager.Instance.GetPlayerVelocity();
		if (targetVelocity == Vector2.Zero)
		{
			//Slows down
			Velocity = Velocity.MoveToward(Vector2.Zero, Friction * (float)delta);
		}
		else
		{
			Velocity = targetVelocity * Speed;
		}
		MoveAndSlide();
	}
}
