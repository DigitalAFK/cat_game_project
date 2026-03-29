using Godot;
using System;

public partial class FoldContainer : FoldableContainer
{
	[Export] private String _id = "ISL000";
	[Export] private int _backgroundOGSizeX = 259;
	[Export] private int _backgroundOGSizeY = 314;
	[Export] private int _containerUnfoldedSizeY = 120;
	[Export] private int _containerFoldedSizeY = 31;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Folded = true;
		FoldingChanged += OnFolded;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnFolded(bool folded)
	{
		var sprite = GetNode<Sprite2D>("../Rectangle");
		GD.Print(sprite);
		//rounded scale y of the space the unfolded container needs
		float roundedY = (float)Math.Round((double)(_containerUnfoldedSizeY - _containerFoldedSizeY) / _backgroundOGSizeY, 3);
		GD.Print(roundedY);
		if (!folded)    //make background bigger
		{
			CustomMinimumSize = new Vector2(0, _containerUnfoldedSizeY);
			sprite.Scale = new Vector2(sprite.Scale.X, sprite.Scale.Y + roundedY);
			sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y + ((_containerUnfoldedSizeY - _containerFoldedSizeY) / 2));
		}
		else    //make background smaller
		{
			CustomMinimumSize = new Vector2(0, 0);
			sprite.Scale = new Vector2(sprite.Scale.X, sprite.Scale.Y - roundedY);
			sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y - ((_containerUnfoldedSizeY - _containerFoldedSizeY) / 2));
		}
	}
}
