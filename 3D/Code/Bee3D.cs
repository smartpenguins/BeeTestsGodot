using Godot;
using System;

public partial class Bee3D : Node3D
{
	[Export] int speed = 8;
	[Export] int radius = 6;
	
	Vector3 startPoint;
	Vector3 nextPoint;
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
		if(Position.DistanceSquaredTo(nextPoint)<4){
			// square
			//nextPoint = startPoint + new Vector2(random.RandfRange(-radius,radius),random.RandfRange(-radius,radius));

			// circal
			float angleRad = random.RandfRange(-MathF.PI,MathF.PI);
			nextPoint = startPoint + new Vector3(MathF.Cos(angleRad),MathF.Sin(angleRad),0)*random.RandfRange(0,radius);
		}
		Position += Position.DirectionTo(nextPoint) * (speed * (float)delta);
	}

}
