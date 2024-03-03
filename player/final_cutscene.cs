using Godot;
using System;

public partial class final_cutscene : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previ"res://Art/Songs/Fallen Stage Two.mp3"ous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_accept"))
		{
			var global = (PlayerVariables) GetNode("/root/PlayerVariables");
			global.FinalLevel();
			GetTree().ChangeSceneToFile("res://player/boss.tscn");
		}
	}
}
