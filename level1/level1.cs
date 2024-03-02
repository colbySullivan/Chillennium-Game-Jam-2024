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
	
	private void _on_despawn_timer_timeout()
	{
		QueueFree();
	}
	
	private void _on_spawn_timer_timeout()
	{
		// Bat
		var scene = GD.Load<PackedScene>("res://player/bat.tscn");
		var instance = scene.Instantiate();
		//instance.Positon.X = _Ouro.Position.X + 10;
		AddChild(instance);
		
		// Scoprion
		//var scene = GD.Load<PackedScene>("res://player/scorpion.tscn");
		//var instance = scene.Instantiate();
		////instance.Positon.X = _Ouro.Position.X + 10;
		//AddChild(instance);
	}
}
