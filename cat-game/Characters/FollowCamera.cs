using Godot;
using System;

public partial class FollowCamera : Camera2D
{
	[Export] private Node2D _target = null;
	[Export] private float _speed = 5f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (_target == null)
		{
			GD.PushWarning("FollowCamera: Target is not set!");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_target == null)
		{
			// There's no target, no can do!
			return;
		}
	}

	public void SetTarget(Node2D newTarget)
	{
		if (newTarget != null)
		{
			_target = newTarget;
		}
	}
}
