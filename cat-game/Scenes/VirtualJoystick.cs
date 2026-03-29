using System;
using Godot;

namespace GA.Common.UI;

public partial class VirtualJoystick : Node2D
{
	[Export] public Sprite2D _knob;
	[Export] private float _radius = 200;
	[Export] private StringName _leftAction = "ui_left";
	[Export] private StringName _rightAction = "ui_right";
	[Export] private StringName _upAction = "ui_up";
	[Export] private StringName _downAction = "ui_down";
	[Export] private bool _useOnlyInBuild = false;

	public Vector2 RelativePosition { get; set; } = Vector2.Zero;

	public override void _Process(double delta)
	{
		if (_useOnlyInBuild && OS.HasFeature("editor"))
		{
			return;
		}

		HandleActionRelease();
		HandleActionPress();
	}

	Vector2 direction;
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		Vector2 startPos = new Vector2(0, 0);

		if (@event is InputEventScreenTouch touch && touch.Pressed)
		{
			startPos = touch.Position;
		}

		if (@event is InputEventScreenDrag drag)
		{

			Vector2 offset = drag.Position - startPos;

			// The drag offset drives everything:
			Vector2 clamped = offset.LimitLength(_radius);

			direction = clamped / _radius; // analog movement

		}
	}

	private void HandleActionPress()
	{
		if (_useOnlyInBuild && OS.HasFeature("editor"))
		{
			return;
		}

		if (InputMap.HasAction(_leftAction) && RelativePosition.X < 0)
		{
			Input.ActionPress(_leftAction, -RelativePosition.X);
		}
		else if (InputMap.HasAction(_rightAction) && RelativePosition.X > 0)
		{
			Input.ActionPress(_rightAction, RelativePosition.X);
		}
		if (InputMap.HasAction(_upAction) && RelativePosition.Y < 0)
		{
			Input.ActionPress(_upAction, -RelativePosition.Y);
		}
		else if (InputMap.HasAction(_downAction) && RelativePosition.Y > 0)
		{
			Input.ActionPress(_downAction, RelativePosition.Y);
		}
	}


	private void HandleActionRelease()
	{
		if (_useOnlyInBuild && OS.HasFeature("editor"))
		{
			return;
		}

		if (InputMap.HasAction(_leftAction) && RelativePosition.X >= 0 && Input.IsActionPressed(_leftAction))
		{
			Input.ActionRelease(_leftAction);
		}
		if (InputMap.HasAction(_rightAction) && RelativePosition.X <= 0 && Input.IsActionPressed(_rightAction))
		{
			Input.ActionRelease(_rightAction);
		}
		if (InputMap.HasAction(_upAction) && RelativePosition.Y >= 0 && Input.IsActionPressed(_upAction))
		{
			Input.ActionRelease(_upAction);
		}
		if (InputMap.HasAction(_downAction) && RelativePosition.Y <= 0 && Input.IsActionPressed(_downAction))
		{
			Input.ActionRelease(_downAction);
		}
	}
}
