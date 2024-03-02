using Godot;
using System;

public partial class FirstCutScene : Node2D
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
			GetTree().ChangeSceneToFile("res://level1/level1.tscn");
		}
	}
	private void _on_button_timer_timeout()
	{
	}
}



