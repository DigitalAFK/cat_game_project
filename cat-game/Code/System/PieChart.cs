using Godot;
using System;

public partial class PieChart : Control
{
	[Export] int _pieChartX = 180;
	[Export] int _pieChartY = 500;
	private static int _maxScore = GameManager.Instance.GetMaxScore();

	//Get all the scores from Game Manager:
	private static int[] _scores = {GameManager.Instance.GetScore(ScoreType.Finder),
									GameManager.Instance.GetScore(ScoreType.Advancer),
									GameManager.Instance.GetScore(ScoreType.Promoter)};

	//Make the scores into an array of percentages:
	float[] Percentages = { (float)_scores[0]/_maxScore * 100,
							(float)_scores[1]/_maxScore * 100,
							(float)_scores[2]/_maxScore * 100 };

	//Colors of the pie chart:
	public Color[] Colors =
	{
		new Color("#c02931"),
		new Color("#a13d77"),
		new Color("#3c1c43")
	};

	public float radius = 240f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Position = new Vector2(_pieChartX, _pieChartY);
	}

	/// <summary>
	/// Draws the pie chart by calling method DrawPieSlice or DrawCircle
	/// </summary>
	public override void _Draw()
	{
		float startAngle = -90f; // Start at top

		//IDK how to get the right font here but i dont think it actually matters because we only print a few numbers
		Font font = GetThemeFont("JetBrains");

		//Goes through all the percentages
		for (int i = 0; i < Percentages.Length; i++)
		{
			//Sweep tells how much area the percentage covers
			float sweep = 360f * (Percentages[i] / 100f);
			GD.Print(sweep);
			if (sweep == 360)
			{
				//Draw the circle at (0, 0) because the node's position has already been set
				DrawCircle(new Vector2(0, 0), radius, Colors[i]);
				GD.Print(radius);
				return;
			}

			DrawPieSlice(startAngle, sweep, Colors[i]);

			//Get the middle angle
			float midAngleDeg = startAngle + sweep / 2f;
			float midAngleRad = Mathf.DegToRad(midAngleDeg);

			//Update starting angle of slice:
			startAngle += sweep;
		}
	}

	/// <summary>
	/// Draws a pie slice.
	/// </summary>
	/// <param name="startDegree">The degree at which the slice begins</param>
	/// <param name="sweepDegree">How big the slice is</param>
	/// <param name="color">The color of the pie slice</param>
	private void DrawPieSlice(float startDegree, float sweepDegree, Color color)
	{
		//more segments, smoother circle
		int segments = 40;
		//Change degrees to radians:
		float startRad = Mathf.DegToRad(startDegree);
		float sweepRad = Mathf.DegToRad(sweepDegree);

		Vector2[] points = new Vector2[segments + 2]; //+2 because the center- and end-points aren't counted in segments
		points[0] = Vector2.Zero;

		//Get all the points for the shape:
		for (int i = 0; i <= segments; i++)
		{
			float t = startRad + sweepRad * ((float)i / segments);
			points[i + 1] = new Vector2(Mathf.Cos(t), Mathf.Sin(t)) * radius;
		}

		//Draws the polygon of one score:
		DrawPolygon(points, new Color[] { color });
	}
}
