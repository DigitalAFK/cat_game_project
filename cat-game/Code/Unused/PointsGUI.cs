using Godot;
using System;

public partial class PointsGUI : Node
{
	private int _islandAmount = 3;
	private int _npcAmount = 3;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		for (int i = 0; i < _islandAmount; i++)
		{

			for (int j = 0; j < _npcAmount; i++)
			{

			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
