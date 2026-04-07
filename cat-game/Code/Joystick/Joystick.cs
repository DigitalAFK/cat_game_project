using Godot;
using System;

public partial class Joystick : Control
{
	[Export] public float HandleLimit = 50f;
	[Export] public TextureRect _knob;
	private Vector2 _input = Vector2.Zero;
	private Vector2 _inputStartPosition;
	private Vector2 _knobStartPosition;

	public override void _Ready()
	{
		//Set start positions
		_inputStartPosition = Vector2.Zero;
		_knobStartPosition = _knob.Position;
	}

	public override void _GuiInput(InputEvent @event)
	{
		if (@event is InputEventScreenTouch touch)
		{
			//At first touch be at start
			if (touch.Pressed)
			{
				_input = _inputStartPosition;
				_knob.Position = _knobStartPosition;
			}
			//At letting go return to start
			else
			{
				_input = _inputStartPosition;
				_knob.Position = _knobStartPosition;
			}
		}
		else if (@event is InputEventScreenDrag drag)
		{
			Vector2 delta = drag.Position - _inputStartPosition;
			if (delta.Length() > HandleLimit)
				delta = delta.Normalized() * HandleLimit;
			_knob.Position = _knobStartPosition + delta;
			_input = delta / HandleLimit;
		}
		SetDirection();
	}

	//Give input to Game Manager so it can be taken from there
	public void SetDirection()
	{
		GameManager.Instance.SetPlayerVelocity(_input);
	}
}
