using Godot;
using System;

public partial class NewPlayerCharacter : CharacterBody2D
{
	[Export] public float Speed = 550.0f;
	[Export] public float Friction = 350.0f;

	public override void _Ready()
	{
		//Check for the last exit
		if (!String.IsNullOrEmpty(GameManager.Instance.GetLastExitID()))
		{
			String spawnName = $"SpawnFrom{GameManager.Instance.GetLastExitID()}";
			Marker2D spawn = GetNode<Marker2D>($"../{spawnName}");

			try
			{
				GlobalPosition = spawn.GlobalPosition;
				return;
			}
			catch (Exception)   //Dont know what exception this should be
			{
				GD.PrintErr("Marker2D spawn node not found");
			}
		}
		GlobalPosition = GetNode<Marker2D>("../DefaultSpawn").GlobalPosition;
	}

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

	public Vector2 PlayerPosition()
	{
		return GlobalPosition;
	}
}
