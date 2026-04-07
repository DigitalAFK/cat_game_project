using Godot;
using System;

public partial class LabelID : Node
{
	[Export] public String _id = "[ISL]/[NPC]000";

	//Returns id
	public String GetID()
	{
		return _id;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (GameManager.Instance.HasVisitedScene(_id))
		{
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
