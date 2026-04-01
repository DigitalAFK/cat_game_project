using Godot;
using System;

public partial class Joystick : Control
{
	[Export] public float HandleLimit = 50f;
	[Export] public TextureRect _knob;
	private Vector2 _input = Vector2.Zero;
	private Vector2 _startPosition;
	private Vector2 _radius = new Vector2(-1, -1);

	public override void _Ready()
	{
		//Dont know how to make this work
		_startPosition = _knob.Position - _radius;
	}

	public override void _GuiInput(InputEvent @event)
	{
		if (@event is InputEventScreenTouch touch)
		{
			if (touch.Pressed)
				_knob.Position = _startPosition;
			else
			{
				_input = Vector2.Zero;
				_knob.Position = _startPosition;
			}
		}
		else if (@event is InputEventScreenDrag drag)
		{
			Vector2 delta = drag.Position - _startPosition;
			if (delta.Length() > HandleLimit)
				delta = delta.Normalized() * HandleLimit;
			_knob.Position = _startPosition + delta;
			_input = delta / HandleLimit;
		}
		SetDirection();
	}

	public void SetDirection()
	{
		GameManager.Instance.SetPlayerDirection(_input);
		//GD.Print(_input);
	}
}
