using Godot;
using System;

public partial class FinalCutScene : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var message = GetNode<Label>("NextScene");
		message.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_accept"))
		{
			GetTree().ChangeSceneToFile("res://player/boss.tscn");
		}
	}
	private void _on_button_timer_timeout()
	{
		var message = GetNode<Label>("NextScene");
		message.Show();
	}
}



