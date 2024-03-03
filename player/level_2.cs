using Godot;
using System;

public partial class level_2 : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void _on_portal_body_entered(Node2D body)
	{
		if(body.Name == "Ouro")
		{
			GetTree().ChangeSceneToFile("res://player/final_cutscene.tscn");
		}
	}
	private void _on_fall_area_entered(Area2D area)
	{
		if(area.Name == "Hitbox")
			{
				GetTree().ChangeSceneToFile("res://player/death_scene.tscn");
			}
	}	
}
