using Godot;
using System.Collections.Generic;
//THIS DOESNT FUCKING WORK IDK
public partial class InfiniteBackground : TileMapLayer
{
	[Export] public Node2D Player;
	//[Export] public int TileSize = 200;      // Pixel size of your tile
	[Export] public int LoadRadius = 8;      // Number of tiles around player

	private HashSet<Vector2I> loadedTiles = new HashSet<Vector2I>();

	private Vector2I lastCenter = new(-99999, -99999);

	public override void _Process(double delta)
	{
		if (Player == null)
		{
			GD.Print("hi");
			return;
		}
		Vector2I center = LocalToMap(Player.GlobalPosition);
		if (center != lastCenter)
		{
			lastCenter = center;
			UpdateBackground(center);
		}
	}

	private void UpdateBackground(Vector2I center)
	{
		//int cellX = Mathf.FloorToInt(playerPos.X / TileSize);
		//int cellY = Mathf.FloorToInt(playerPos.Y / TileSize);

		for (int x = center.X - LoadRadius; x <= center.X + LoadRadius; x += 200)
		{
			for (int y = center.Y - LoadRadius; y <= center.Y + LoadRadius; y += 200)
			{
				Vector2I cell = new(x, y);

				if (!loadedTiles.Contains(cell))
				{
					SetTile(cell);
				}
			}
		}
	}

	private void SetTile(Vector2I cell)
	{
		// Tile ID = 0, Atlas coords = (0,0)
		GD.Print("setCell: " + cell);
		SetCell(cell, 1, new Vector2I(0, 0));

		loadedTiles.Add(cell);
	}
}
