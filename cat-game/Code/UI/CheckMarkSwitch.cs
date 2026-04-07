using Godot;
using System;

public partial class CheckMarkSwitch : TextureRect
{
	[Export] public String _id = "NPC000";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (GameManager.Instance.HasVisitedScene(_id))
		{
			SetTexture(true);
		}
		else
		{
			SetTexture(false);
		}
	}

	public void SetTexture(bool mark)
	{
		//TODO: Get real graphics
		if (mark)
		{
			Texture = ResourceLoader.Load<Texture2D>("res://Art/Sprites/CheckMarkTest.jpg");
		}
		else
		{
			Texture = ResourceLoader.Load<Texture2D>("res://Art/Sprites/XMarkTest.jpg");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
