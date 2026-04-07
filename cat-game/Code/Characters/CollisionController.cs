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
		//If next scene already visited and we don't want them re-entering it, disable monitoring
		if (GameManager.Instance.HasVisitedScene(_id) && !_reEnter)
		{
			Monitoring = false;
		}
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		//Update game manager so that we know the next scene has been entered
		GameManager.Instance.MarkVisitedScene(_id);
		//Store the last exit's ID
		GameManager.Instance.SetLastExitID(_id);
		//Go to next scene
		GameManager.Instance.GoToScene(_targetScenePath);
	}
}
