using Godot;
using System;

public partial class boss : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void _on_spawner_timeout()
	{
		var scene = GD.Load<PackedScene>("res://player/bat.tscn");
		var instance = scene.Instantiate();
		AddChild(instance);
	}
	private void _on_fall_area_body_entered(Node2D body)
	{
		if(body.Name == "Ouro")
		{
			GetTree().ChangeSceneToFile("res://player/death_scene.tscn");
		}
	}
}
