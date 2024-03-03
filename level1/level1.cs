using Godot;
using System;

public partial class level1 : Node2D
{
	public CharacterBody2D _Ouro;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_Ouro = GetParent().GetNode<CharacterBody2D>("Ouro");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	private void _on_spawn_timer_timeout()
	{
		// Bat
		var scene = GD.Load<PackedScene>("res://player/bat.tscn");
		var instance = scene.Instantiate();
		AddChild(instance);
	}
	private void _on_portal_body_entered(Node2D body)
	{
		if(body.Name == "Ouro")
		{
			GetTree().ChangeSceneToFile("res://player/level_2.tscn");
		}
	}
	private void _on_area_2d_body_entered(Node2D body)
	{
		if(body.Name == "Ouro")
		{
			GetTree().ChangeSceneToFile("res://level1/level1.cs");
		}
	}
}
