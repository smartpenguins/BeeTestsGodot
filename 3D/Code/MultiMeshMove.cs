using Godot;
using System;
using System.Collections.Generic;

public partial class MultiMeshMove : MultiMeshInstance3D
{

	RandomNumberGenerator random = new RandomNumberGenerator();
	[Export] float radius = .2f;
	[Export] float speed = 3f;
	[Export] string action = "mmf";
	Vector3 startPoint=new Vector3(0,0,0);


	List<Vector3> nextPoints = new List<Vector3>();
	public override void _Ready()
	{
		nextPoints.Clear();
		for(int i=0;i<Multimesh.InstanceCount;i++){
			Transform3D transform = new Transform3D(Basis,startPoint);
			Multimesh.SetInstanceTransform(i,transform);
			nextPoints.Add(startPoint);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	
	public override void _Process(double delta)
	{
		float df = (float) delta;
		for(int i=0;i<Multimesh.InstanceCount;i++){
			Transform3D transform = Multimesh.GetInstanceTransform(i);
			Vector3 nextPoint = nextPoints[i];
			if(transform.Origin.DistanceSquaredTo(nextPoint)<.01f){
				float angleRad = random.RandfRange(-MathF.PI,MathF.PI);
				nextPoint = startPoint + new Vector3(MathF.Cos(angleRad),MathF.Sin(angleRad),0)*random.RandfRange(0,radius);
				nextPoints[i]=nextPoint;
			}
			transform.Origin += transform.Origin.DirectionTo(nextPoint) * (speed * df);
			Multimesh.SetInstanceTransform(i,transform);
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
