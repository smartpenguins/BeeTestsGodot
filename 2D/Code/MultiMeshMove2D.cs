using Godot;
using System;
using System.Collections.Generic;

public partial class MultiMeshMove2D : MultiMeshInstance2D
{
	RandomNumberGenerator random = new RandomNumberGenerator();
	[Export] float radius = .2f;
	[Export] float speed = 3f;
	[Export] string action = "mmf";
	Vector2 startPoint=new Vector2(0,0);

	List<Vector2> nextPoints = new List<Vector2>();
	public override void _Ready()
	{
		GD.Print("here");
		nextPoints.Clear();
		for(int i=0;i<Multimesh.InstanceCount;i++){
			Transform2D transform = new Transform2D(0,startPoint);
			Multimesh.SetInstanceTransform2D(i,transform);
			nextPoints.Add(startPoint);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	
	public override void _Process(double delta)
	{
		float df = (float) delta;
		for(int i=0;i<Multimesh.InstanceCount;i++){
			Transform2D transform = Multimesh.GetInstanceTransform2D(i);
			Vector2 nextPoint = nextPoints[i];
			if(transform.Origin.DistanceSquaredTo(nextPoint)<.1f){
				float angleRad = random.RandfRange(-MathF.PI,MathF.PI);
				nextPoint = startPoint + new Vector2(MathF.Cos(angleRad),MathF.Sin(angleRad))*random.RandfRange(0,radius);
				nextPoints[i]=nextPoint;
			}
			transform.Origin += transform.Origin.DirectionTo(nextPoint) * (speed * df);
			Multimesh.SetInstanceTransform2D(i,transform);
		}
	}


    public override void _Input(InputEvent @event)
    {
		if(@event.IsActionPressed(action)){
			Multimesh.InstanceCount+=1000;
			_Ready();
		}
		if(@event.IsActionPressed("restart")){
			Multimesh.InstanceCount=0;
		}
        base._Input(@event);
    }
}
