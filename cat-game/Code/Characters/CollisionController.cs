using Godot;
using System;
using System.ComponentModel;

public partial class CollisionController : Area2D
{
	[Export] private String _targetScenePath = "res://";
	[Export] private Boolean _reEnter = false;
	[Export] private String _id = "[ISL]/[NPC]000";
	[Export] private String name = "?";

	public override void _EnterTree()
	{
		//If next scene already visited, disable monitoring
		if (GameManager.Instance.HasVisitedScene(_id) && !_reEnter)
		{
			Monitoring = false;
		}
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		//Defer the scene change so that it's after physics finishes and no error :)
		CallDeferred(nameof(DeferredChangeScene));
		//Update game manager so that we know the next scene has been entered
		GameManager.Instance.MarkVisitedScene(_id);
	}

	private void DeferredChangeScene()
	{
		GetTree().ChangeSceneToFile(_targetScenePath);
	}
}
