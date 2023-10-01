using Godot;
using System;

public partial class Bee : Node2D
{
	[Export] int speed = 400;
	[Export] int radius = 300;
	
	Vector2 startPoint;
	Vector2 nextPoint;
	RandomNumberGenerator random = new RandomNumberGenerator();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		startPoint=Position;
		nextPoint=Position;
		 
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Position.DistanceSquaredTo(nextPoint)<144){
			// square
			//nextPoint = startPoint + new Vector2(random.RandfRange(-radius,radius),random.RandfRange(-radius,radius));

			// circal
			var angleRad = random.RandfRange(-MathF.PI,MathF.PI);
			nextPoint = startPoint + new Vector2(MathF.Cos(angleRad),MathF.Sin(angleRad))*random.RandfRange(0,radius);
		}
		Position += Position.DirectionTo(nextPoint) * (speed * (float)delta);
	}




}
