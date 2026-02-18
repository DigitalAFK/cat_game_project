using Godot;
using System;

public partial class PlayerCharacter : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	private bool _isMovingLeft = false;
	private bool _isMovingUp = false;
	private bool _isMovingRight = false;
	private bool _isMovingDown = false;

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed(InputConfig.InputUp))
		{
			_isMovingUp = true;
		}
		if (@event.IsActionPressed(InputConfig.InputDown))
		{
			_isMovingDown = true;
		}
	}
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed(InputConfig.InputLeft))
		{
			_isMovingLeft = true;
		}
		if (Input.IsActionPressed(InputConfig.InputRight))
		{
			_isMovingRight = true;
		}
		if (Input.IsActionPressed(InputConfig.InputUp))
		{
			_isMovingUp = true;
		}
		if (Input.IsActionPressed(InputConfig.InputDown))
		{
			_isMovingDown = true;
		}
	}
	public override void _PhysicsProcess(double delta)
	{

		// Handle vertical movement.
		if (_isMovingUp)
		{
			GD.Print("Up");
			_isMovingUp = false;
		}
		if (_isMovingDown)
		{
			GD.Print("Down");
			_isMovingDown = false;
		}

		//Handle horizontal movement
		if (_isMovingLeft)
		{
			GD.Print("Left");
			_isMovingLeft = false;
		}
		if (_isMovingRight)
		{
			GD.Print("Right");
			_isMovingRight = false;
		}
	}
}
