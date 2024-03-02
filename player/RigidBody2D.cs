using Godot;
using System;

public partial class RigidBody2D : Godot.RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_accept"))
		{
			//AddForce(new Vector2(10,10),new Vector2(10,10));
		}
	}
}
